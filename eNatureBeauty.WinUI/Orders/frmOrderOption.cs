using eNatureBeauty.WinUI.Products;
using System;
using System.Windows.Forms;

namespace eNatureBeauty.WinUI.Orders
{
    public partial class frmOrderOption : Form
    {
        private readonly Model.Orders _orders;
        public frmOrderOption(Model.Orders order = null)
        {
            _orders = order;
            InitializeComponent();
        }

        private void btnStatus_Click(object sender, EventArgs e)
        {
            this.Close();
            frmOrderStatus frm = new frmOrderStatus(_orders);
            frm.ShowDialog();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            this.Close();

            frmProducts frm = new frmProducts(_orders);
            frm.ShowDialog();
        }
    }
}
