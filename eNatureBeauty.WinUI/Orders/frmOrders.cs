using eNatureBeauty.Model.Requests.Orders;
using eNatureBeauty.Model.Requests.Outputs;
using eNatureBeauty.WinUI.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eNatureBeauty.WinUI.Orders
{
    public partial class frmOrders : Form
    {
        private readonly APIService _service = new APIService("products");
        private readonly APIService _outputsService = new APIService("outputs");
        private readonly APIService _ordersService = new APIService("orders");
        private readonly APIService _outputsProductsService = new APIService("outputProducts");
        private readonly APIService _inputsProductsService = new APIService("inputProducts");
        private readonly APIService _inputsService = new APIService("inputs");
        private readonly APIService _productTypesService = new APIService("productTypes");
        private Model.Products _product;
        public frmOrders()
        {
            InitializeComponent();
        }
        private void frmOrders_Load(object sender, EventArgs e)
        {
            LoadOrders();
        }
        private async void LoadOrders()
        {
            OrdersSearchRequest request = new OrdersSearchRequest
            {
                OrderNumber = txtSearch.Text
            };
            List<Model.Orders> result = await _ordersService.Get<List<Model.Orders>>(request);//because we have filter as
            dgvOrders.AutoGenerateColumns = false;
            dgvOrders.DataSource = result;
        }

        private async void dgvOrders_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try { 
            Model.Orders id = (Model.Orders)dgvOrders.SelectedRows[0].DataBoundItem;
            var model = await _ordersService.GetById<Model.Orders>(id.Id);
            frmOrderOption frm = new frmOrderOption(model);
            frm.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Nothing selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            OrdersSearchRequest request = new OrdersSearchRequest
            {
                OrderNumber = txtSearch.Text
            };
            var result = await _ordersService.Get<List<Model.Orders>>(request);
            dgvOrders.DataSource = result;
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            Model.Orders id = (Model.Orders)dgvOrders.SelectedRows[0].DataBoundItem;
            var model = await _ordersService.GetById<Model.Orders>(id.Id);
            frmProducts frm = new frmProducts(model);
            frm.ShowDialog();
        }

        private async void dgvOrders_Click(object sender, EventArgs e)
        {

        }

        private async void dgvOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try { 
            Model.Orders id = (Model.Orders)dgvOrders.SelectedRows[0].DataBoundItem;
            var model = await _ordersService.GetById<Model.Orders>(id.Id);
            frmOrderOption frm = new frmOrderOption(model);
            frm.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Nothing selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
