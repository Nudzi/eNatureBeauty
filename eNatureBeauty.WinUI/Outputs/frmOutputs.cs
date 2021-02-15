using eNatureBeauty.Model.Requests.Outputs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eNatureBeauty.WinUI.Outputs
{
    public partial class frmOutputs : Form
    {
        private readonly APIService _outputs = new APIService("outputs");

        public frmOutputs()
        {
            InitializeComponent();
        }

        private async void frmOutputs_Load(object sender, EventArgs e)
        {
            var result = await _outputs.Get<List<Model.Outputs>>(null);
            dgvOutputs.DataSource = result;
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            OutputsSearchRequest request = new OutputsSearchRequest
            {
                ReceiveNumber = txtSearch.Text
            };
            var result = await _outputs.Get<List<Model.Outputs>>(request);
            dgvOutputs.DataSource = result;
        }
    }
}
