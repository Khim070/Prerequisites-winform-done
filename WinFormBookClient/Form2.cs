using BookLib;
using RestClientLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormBookClient
{
    public partial class Form2 : Form
    {
        public event EventHandler<string>? BookCreated = null;
        public Form2()
        {
            InitializeComponent();

            btnClear.Click += DoClickClear;
            btnSubmit.Click += DoClickSubmit;
        }

        private async void DoClickSubmit(object? sender, EventArgs e)
        {
            BookCreateReq req = new BookCreateReq()
            {
                Id = txtId.Text,
                Title = txtTitle.Text,
                Pages = int.Parse(txtPages.Text),
            };
            string endpoint = $"{Program.BaseUri}/api/books";
            try
            {
                using (RestClient client = new RestClient())
                {
                    var result = await client.PostAsync<BookCreateReq, Result<string?>>(endpoint, req);
                    if(result!.Data != null)
                    {
                        BookCreated?.Invoke(this, result!.Data!);
                        MessageBox.Show(result!.Message);
                    }
                    else
                    {
                        MessageBox.Show(result!.Message);
                    }
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DoClickClear(object? sender, EventArgs e)
        {
            txtId.Clear();
            txtTitle.Clear();
            txtPages.Clear();
            txtId.Focus();
        }
    }
}
