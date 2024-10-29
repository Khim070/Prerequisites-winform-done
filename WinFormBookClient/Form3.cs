using BookLib;
using RestClientLib;

namespace WinFormBookClient;

public partial class Form3 : Form
{
    private BookResponse? curBook = null;
    public event EventHandler<string>? BookUpdated=null;
    public Form3(BookResponse? book=null)
    {
        InitializeComponent();
        curBook = book;

        txtTitle.DataBindings.Add("ReadOnly", chkTitle, "Checked").Format += (sender, e) =>
        {
            e.Value = !((bool)e.Value!);
        };
        txtPages.DataBindings.Add("ReadOnly", chkPages, "Checked").Format += (sender, e) =>
        {
            e.Value = !((bool)e.Value!);
        };
        ShowCurrentBook();

        btnCancel.Click += (sender, e) => { ShowCurrentBook(); };
        btnSubmit.Click += DoClickSubmit;
        txtId.Leave += DoLeaveId;
    }

    private async void DoLeaveId(object? sender, EventArgs e)
    {
        string id = txtId.Text.Trim();
        if (id.Equals(curBook?.Id)) return;

        string endpoint = $"{Program.BaseUri}/api/books{id}";
        try
        {
            using (RestClient client = new RestClient())
            {
                var result = await client.GetAsync<Result<BookResponse?>>(endpoint);
                if(result != null)
                {
                    curBook = result.Data;
                    ShowCurrentBook();
                }
            }
        }
        catch (Exception ) { }
    }

    private void ShowCurrentBook()
    {
        txtId.Text = curBook?.Id;
        txtTitle.Text = curBook?.Title;
        txtPages.Text = curBook?.Pages?.ToString();
        chkTitle.Checked = false;
        chkPages.Checked = false;
    }

    private async void DoClickSubmit(object? sender, EventArgs e)
    {
        // Create a request for updating
        BookUpdateReq req = new BookUpdateReq()
        {
            Id = txtId.Text,
            UpdateData = []
        };
        if(chkTitle.Checked)
        {
            req.UpdateData.Add(new UpdateData()
            {
                Field = nameof(Book.Title),
                Value = txtTitle.Text
            });
        }
        if(chkPages.Checked)
        {
            int.TryParse(txtPages.Text, out int pages);
            req.UpdateData.Add(new UpdateData()
            {
                Field= nameof(Book.Pages),
                Value = pages
            });
        }
        // Checking any updated data
        if(req.UpdateData.Count == 0)
        {
            MessageBox.Show("It is required at least a data to perform updating.", "Updating", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            return;
        }

        // Submitting to update
        string endpoint = $"{Program.BaseUri}/api/books";
        try{
            using(RestClient client = new RestClient())
            {
                var result = await client.PutAsync<BookUpdateReq, Result<string?>>(endpoint, req);
                if(result!.Data != null)
                {
                    BookUpdated?.Invoke(this, result!.Data);
                }
                MessageBox.Show(result!.Message, "Updating", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }catch(Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
}

   

