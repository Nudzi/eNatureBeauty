using eNatureBeauty.Model.Requests;
using eNatureBeauty.Model.Requests.OutputProducts;
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

namespace eNatureBeauty.WinUI.Products
{
    public partial class frmProducts : Form
    {
        public static int IdOfProduct = 0;
        private readonly APIService _productTypes = new APIService("productTypes");
        private readonly APIService _products = new APIService("products");
        private readonly APIService _outputsService = new APIService("outputs");
        private readonly APIService _outputProductsService = new APIService("outputProducts");
        private readonly Model.Orders _orders;
        public frmProducts(Model.Orders order = null)
        {
            _orders = order;
            InitializeComponent();
        }

        private async void frmProductsAll_Load(object sender, EventArgs e)
        {
            await LoadProductTypes();
            await LoadProducts();
        }

        private async void cmbProductTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idObj = cmbIngredientTypes.SelectedValue; //idObj because it is object in service
            if (int.TryParse(idObj.ToString(), out int id))//so we need to parse it 
            {
                await LoadProducts(id);
            }
        }
        private async Task LoadProductTypes()
        {
            var result = await _productTypes.Get<List<Model.ProductTypes>>(null);
            result.Insert(0, new Model.ProductTypes("All"));//first empty record
            cmbIngredientTypes.DataSource = result;
            cmbIngredientTypes.DisplayMember = "Name";
            cmbIngredientTypes.ValueMember = "Id";
        }
        private async Task LoadProductsWithNoOrder(int productTypesId = 0)
        {
            List<Model.Products> result;
            if (productTypesId != 0)
            {
                result = await _products.Get<List<Model.Products>>(new ProductsSearchRequest()//because we have filter as
                {                                                                                   //object, but we need our one
                    ProductTypeId = productTypesId
                });
            }
            else
            {
                result = await _products.Get<List<Model.Products>>("");
            }
            dgvProducts.AutoGenerateColumns = false;

            dgvProducts.DataSource = result;
        }
        private async Task LoadProducts(int productTypesId = 0)
        {
            if (_orders == null)
                await LoadProductsWithNoOrder(productTypesId);
            else
                await LoadProductsFromOrder(productTypesId);
        }
        private async Task LoadProductsFromOrder(int productTypesId = 0)
        {
            try
            {
                OutputsSearchRequest orequest = new OutputsSearchRequest
                {
                    OrderId = _orders.Id
                };
                var output = await _outputsService.Get<List<Model.Outputs>>(orequest);

                OutputProductsSearchRequest oprequest = new OutputProductsSearchRequest
                {
                    OutputId = output.FirstOrDefault().Id,
                };
                var result = await _outputProductsService.Get<List<Model.OutputProducts>>(oprequest);
                List<Model.Products> list = new List<Model.Products>();
                foreach (var item in result)
                {
                    Model.Products tmp = await _products.GetById<Model.Products>(item.ProductId);
                    list.Add(tmp);
                }

                var query = list.AsQueryable();
                if (!string.IsNullOrWhiteSpace(txtSearchName?.Text))
                    query = query.Where(x => x.Name.StartsWith(txtSearchName.Text));

                query = query.OrderBy(x => x.Name);
                var finalResults = query.ToList();

                dgvProducts.AutoGenerateColumns = false;
                var productTypesProducts = new List<Model.Products>();
                if (productTypesId != 0)
                {
                    foreach (var item in finalResults)
                        if (item.ProductTypeId == productTypesId)
                            productTypesProducts.Add(item);

                    dgvProducts.DataSource = productTypesProducts;
                }
                else
                    dgvProducts.DataSource = finalResults;
            }
            catch(Exception ex)
            {
                MessageBox.Show("This order has no products in list", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            if (_orders == null)
            {
                var search = new ProductsSearchRequest()
                {
                    ProductName = txtSearchName.Text
                };
                var result = await _products.Get<List<Model.Products>>(search);
                dgvProducts.AutoGenerateColumns = false;
                dgvProducts.DataSource = result;
            }
            else
                await LoadProductsFromOrder();
        }

        private void dgvProducts_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                var id = dgvProducts.SelectedRows[0].DataBoundItem;
                frmProductEdit frm = new frmProductEdit(id as Model.Products);
                Global.shouldEditProduct = true;
                frm.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Nothing selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var id = dgvProducts.SelectedRows[0].DataBoundItem;
                frmProductEdit frm = new frmProductEdit(id as Model.Products);
                Global.shouldEditProduct = true;
                frm.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Nothing selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            frmProductsCompare frm = new frmProductsCompare();
            Global.shouldEditProduct = true;
            frm.ShowDialog();
        }
    }
}
