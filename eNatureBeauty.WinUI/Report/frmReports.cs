using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eNatureBeauty.WinUI.Report
{
    public partial class frmReports : Form
    {
        private readonly APIService _ordersService = new APIService("orders");
        private readonly APIService _inputsService = new APIService("inputs");
        private readonly APIService _outputsService = new APIService("outputs");
        private string Enable = "Enable";
        private string Disable = "Disable";

        public frmReports()
        {
            InitializeComponent();
        }
        Bitmap bmp;
        private void btnPrint_Click(object sender, EventArgs e)
        {
            int height = dgvResults.Height;
            dgvResults.Height = dgvResults.RowCount * dgvResults.RowTemplate.Height * 2;
            bmp = new Bitmap(dgvResults.Width, dgvResults.Height);
            dgvResults.DrawToBitmap(bmp, new Rectangle(0, 0, dgvResults.Width, dgvResults.Height));
            dgvResults.Height = height;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0);
        }

        private async void btnOrders_Click(object sender, EventArgs e)
        {
            var orders = await _ordersService.Get<List<Model.Orders>>(null);

            var result = new List<Model.Orders>();
            foreach (var item in orders)
            {
                if (item.Date > dtpFrom.Value && item.Date < dtpTo.Value)
                    result.Add(item);
            }
            dgvResults.DataSource = result;
            for (int i = 0; i < dgvResults.Columns.Count; i++)
                dgvResults.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private async void btnInputs_Click(object sender, EventArgs e)
        {
            var inputs = await _inputsService.Get<List<Model.Inputs>>(null);
            var result = new List<Model.Inputs>();
            foreach (var item in inputs)
            {
                if (item.Date > dtpFrom.Value && item.Date < dtpTo.Value)
                    result.Add(item);
            }
            dgvResults.DataSource = result;
            for (int i = 0; i < dgvResults.Columns.Count; i++)
                dgvResults.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

        }

        private async void btnOutputs_Click(object sender, EventArgs e)
        {
            var outputs = await _outputsService.Get<List<Model.Outputs>>(null);
            var result = new List<Model.Outputs>();
            foreach (var item in outputs)
            {
                if (item.Date > dtpFrom.Value && item.Date < dtpTo.Value)
                    result.Add(item);
            }
            dgvResults.DataSource = result;
            for (int i = 0; i < dgvResults.Columns.Count; i++)
                dgvResults.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void btnFromDisable_Click(object sender, EventArgs e)
        {
            if (btnFromDisable.Text.Equals(Disable))
            {
                dtpFrom.Enabled = false;
                btnFromDisable.Text = Enable;
                dtpFrom.Value = dtpTo.MinDate;
                return;
            }
            else if (btnFromDisable.Text.Equals(Enable))
            {
                dtpFrom.Enabled = true;
                btnFromDisable.Text = Disable;
                dtpFrom.Value = DateTime.Now;
                return;
            }
        }
        private void btnToDisable_Click(object sender, EventArgs e)
        {
            if (btnToDisable.Text.Equals(Disable))
            {
                dtpTo.Enabled = false;
                btnToDisable.Text = Enable;
                dtpTo.Value = dtpTo.MaxDate;
                return;
            }
            else if (btnToDisable.Text.Equals(Enable))
            {
                dtpTo.Enabled = true;
                btnToDisable.Text = Disable;
                dtpTo.Value = DateTime.Now;
                return;
            }
        }
    }
}
