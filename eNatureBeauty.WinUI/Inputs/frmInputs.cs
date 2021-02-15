using eNatureBeauty.Model.Requests.Inputs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eNatureBeauty.WinUI.Inputs
{
    public partial class frmInputs : Form
    {
        private readonly APIService _inputs = new APIService("inputs");

        public frmInputs()
        {
            InitializeComponent();
        }

        private async void frmInputs_Load(object sender, EventArgs e)
        {
            var result = await _inputs.Get<List<Model.Inputs>>(null);
            dgvInputs.DataSource = result;
        }
        private async Task LoadInputs()
        {

        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            InputsSearchRequest request = new InputsSearchRequest
            {
                InvoiceNumber = txtSearch.Text
            };
            var result = await _inputs.Get<List<Model.Inputs>>(request);
            dgvInputs.DataSource = result;
        }
    }
}
