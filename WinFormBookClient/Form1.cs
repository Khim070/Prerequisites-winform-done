using BookLib;
using RestClientLib;

namespace WinFormBookClient;

public partial class Form1 : Form
{
    private BindingSource bs = new();
    private List<BookResponse> books = new List<BookResponse>();
    public Form1()
    {
        InitializeComponent();
        bs.DataSource = books;
        dgvBooks.DataSource = bs;
        dgvBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        DataGridView.CheckForIllegalCrossThreadCalls = false;

        btnRefresh.Click += DoClickRefresh;
        btnDelete.Click += DoClickDelete;
        btnNew.Click += DoClickNew;
        btnEdit.Click += DoClickEdit;
    }

    private async void DoClickRefresh(object? sender, EventArgs e)
    {
        string endpoint = $"{Program.BaseUri}/api/books";
        try
        {
            using (RestClient client = new RestClient())
            {
                var result = await client.GetAsync<Result<List<BookResponse>>>(endpoint);
                if (result!.Succeded)
                {
                    books.Clear();
                    books.AddRange(result!.Data!);
                    bs.ResetBindings(false);
                }
                else
                {
                    MessageBox.Show(result.Message);
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void DoClickEdit(object? sender, EventArgs e)
    {
        var frm = new Form3();
        frm.BookUpdated += DoClickBookUpdated;
        frm.Show();
    }

    private void DoClickBookUpdated(object? sender, string e)
    {
        Task.Run(async () =>
        {
            string endpoint = $"{Program.BaseUri}/api/books/{e}";
            try
            {
                using(RestClient client = new RestClient())
                {
                    var result = await client.GetAsync<Result<BookResponse?>>(endpoint);
                    if(result != null)
                    {
                        var updated = result.Data;
                        var found = books.FirstOrDefault(x => x.Id == updated!.Id);
                        if(found != null)
                        {
                            found.Title = updated?.Title;
                            found.Pages = updated?.Pages;
                            bs.ResetBindings(false);
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        });
    }

    private void DoClickNew(object? sender, EventArgs e)
    {
        var frm = new Form2();
        frm.BookCreated += DoBookCreated;
        frm.Show();
    }

    private void DoBookCreated(object? sender, string e)
    {
        Task.Run(async () =>
        {
            
            try
            {
                string endpoint = $"{Program.BaseUri}/api/books/{e}";
                using (RestClient client = new RestClient())
                {
                    var result = await client.GetAsync<Result<BookResponse?>>(endpoint);
                    if(result != null)
                    {
                        var created = result.Data;
                        if(created != null)
                        {
                            books.Add(created);
                            bs.ResetBindings(false);
                        }
                    }
                }
            }
            catch (Exception) { }
        });
    }

    private async void DoClickDelete(object? sender, EventArgs e)
    {
        if (bs.Current == null) return;
        var dlgresult = MessageBox.Show("Are your sure to delete the current product?",
                                     "Deleting",
                                     MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Question);
        if (dlgresult == DialogResult.No) return;

        BookResponse bk = (bs.Current as BookResponse)!;
        string endpoint = $"{Program.BaseUri}/api/books/{bk!.Id}";
        try
        {
            using (RestClient client = new RestClient())
            {
                var result = await client.DeleteAsync<Result<string?>>(endpoint);
                if(result!.Succeded )
                {
                    books.Remove(bk);
                    bs.ResetBindings(false);
                }
                MessageBox.Show(result.Message, "Deleting", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Deleting", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
