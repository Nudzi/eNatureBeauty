using eNatureBeauty.Model.Requests;
using eNatureBeauty.Model.Requests.InputProducts;
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
    public partial class frmInputsProductsAdd : Form
    {
        private readonly APIService _productsService = new APIService("products");
        private readonly APIService _inputsService = new APIService("inputs");
        private readonly APIService _inputProductsService = new APIService("inputProducts");
        private Model.Inputs _input;
        private List<InputProductsAdd> _productsAdd;
        public frmInputsProductsAdd(Model.Inputs input)
        {
            InitializeComponent();
            _productsAdd = new List<InputProductsAdd>();
            _input = input;
        }
        private async Task LoadProducts()
        {
            var search = new ProductsSearchRequest()
            {
                ProductName = txtSearch.Text
            };
            List<Model.Products> result = await _productsService.Get<List<Model.Products>>(search);
            List<Model.Products> newList = new List<Model.Products>(result);
            foreach (var item in result)
            {
                if (_productsAdd.Where(x => x.ProductId == item.Id).Any())
                    newList.Remove(item);
            }
            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.DataSource = newList;
        }

        private async void dgvProducts_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Model.Products product = (Model.Products)dgvProducts.SelectedRows[0].DataBoundItem;
            var model = await _productsService.GetById<Model.Products>(product.Id);
            InputProductsAdd tmp = new InputProductsAdd
            {
                ProductId = model.Id,
                Name = model.Name,
                Quantity = 1
            };
            _productsAdd.Add(tmp);
            dgvProducts.AutoGenerateColumns = false;
            dgvInputProducts.DataSource = null;
            dgvProducts.DataSource = null;
            dgvInputProducts.DataSource = _productsAdd;
            await LoadProducts();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            await LoadProducts();
        }

        private void dgvInputProducts_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // Don't throw an exception when we're done.
            e.ThrowException = false;

            // Display an error message.
            string txt = "Error with " +
                dgvInputProducts.Columns[e.ColumnIndex].HeaderText +
                "\n\n" + e.Exception.Message;
            MessageBox.Show(txt, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);

            // If this is true, then the user is trapped in this cell.
            e.Cancel = false;
        }
        private void dgvInputProducts_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (int.Parse(dgvInputProducts.SelectedCells[0].Value.ToString()) < 1)
            {
                string txt = "Error with " +
                dgvInputProducts.Columns[e.ColumnIndex].HeaderText +
                "\n\n" + " can't insert values lower than 1";
                MessageBox.Show(txt, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvInputProducts.SelectedCells[0].Value = 1;
            }
        }

        private async void txtRemove_Click(object sender, EventArgs e)
        {
            if ((InputProductsAdd)dgvInputProducts.SelectedRows[0].DataBoundItem != null)
            {
                InputProductsAdd product = (InputProductsAdd)dgvInputProducts.SelectedRows[0].DataBoundItem;
                _productsAdd.Remove(product);
                dgvProducts.AutoGenerateColumns = false;
                dgvInputProducts.DataSource = null;
                dgvProducts.DataSource = null;
                dgvInputProducts.DataSource = _productsAdd;
                await LoadProducts();
            }
            else
            {
                MessageBox.Show("Nothing selected to remove!");
            }
        }

        private async void frmInputProductsAdd_Load_1(object sender, EventArgs e)
        {
            await LoadProducts();
        }

        private async void dgvInputProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvInputProducts.SelectedCells.Count > 0)
            {
                int selectedrowindex = dgvInputProducts.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvInputProducts.Rows[selectedrowindex];
                string cellValue = Convert.ToString(selectedRow.Cells["ProductId"].Value);
                var list = new List<InputProductsAdd>(_productsAdd);
                foreach (var item in list)
                {
                    if (item.ProductId.ToString() == cellValue)
                        _productsAdd.Remove(item);
                }
                dgvProducts.AutoGenerateColumns = false;
                dgvInputProducts.DataSource = null;
                dgvProducts.DataSource = null;
                dgvInputProducts.DataSource = _productsAdd;
                await LoadProducts();
            }
            else
            {
                MessageBox.Show("Nothing selected to remove!");
            }
        }
        bool cancelIt = false;
        private void dgvInputProducts_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            cancelIt = true;
        }
        private async void LoadAll()
        {
            dgvProducts.AutoGenerateColumns = false;
            dgvInputProducts.DataSource = null;
            dgvProducts.DataSource = null;
            dgvInputProducts.DataSource = _productsAdd;
            await LoadProducts();
        }

        private void dgvInputProducts_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

        }

        private async void btnModify_Click(object sender, EventArgs e)
        {
            if (numModify.Value == 0)
                MessageBox.Show("Not able to add 0 number of products!");
            else
            {
                InputProductsAdd product = (InputProductsAdd)dgvInputProducts.SelectedRows[0].DataBoundItem;
                var model = _productsAdd.Where(x => x.ProductId == product.ProductId).FirstOrDefault();
                model.Quantity = (int)numModify.Value;

                dgvProducts.AutoGenerateColumns = false;
                dgvInputProducts.DataSource = null;
                dgvProducts.DataSource = null;
                dgvInputProducts.DataSource = _productsAdd;
                await LoadProducts();
            }
        }

        private async void dgvInputProducts_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            InputProductsAdd product = (InputProductsAdd)dgvInputProducts.SelectedRows[0].DataBoundItem;
            var model = _productsAdd.Where(x => x.ProductId == product.ProductId).FirstOrDefault();
            _productsAdd.Remove(model);
            dgvProducts.AutoGenerateColumns = false;
            dgvInputProducts.DataSource = null;
            dgvProducts.DataSource = null;
            dgvInputProducts.DataSource = _productsAdd;
            await LoadProducts();
        }

        
        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (_productsAdd.Count == 0)
            {
                MessageBox.Show("No added products!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                await Helper.CalculateInputProductsPrice(_productsAdd);
                List<InputProductsUpsertRequest> list = new List<InputProductsUpsertRequest>();
                foreach (var item in _productsAdd)
                {
                    InputProductsUpsertRequest request = new InputProductsUpsertRequest
                    {
                        InputId = _input.Id,
                        ProductId = item.ProductId,
                        Price = item.Price,
                        Quantity = item.Quantity
                    };
                    try
                    {
                        await _inputProductsService.Insert<Model.InputProducts>(request);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                await CalculateInvoiceAmount();
                MessageBox.Show("Success", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
        private async Task CalculateInvoiceAmount()
        {
            InputProductsSearchRequest request = new InputProductsSearchRequest
            {
                InputId = _input.Id
            };
            List<Model.InputProducts> list = await _inputProductsService.Get<List<Model.InputProducts>>(request);
            decimal amount = 0;
            foreach (var item in list)
                amount += item.Price;

            _input.InvoiceAmount = amount;
            _input.InvoiceAmountWithPDV = amount - ((amount * _input.Pdv) / 100);
            try
            {
                await _inputsService.Update<Model.Inputs>(_input.Id, _input);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
