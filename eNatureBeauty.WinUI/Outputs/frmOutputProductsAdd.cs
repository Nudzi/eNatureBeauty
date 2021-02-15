using eNatureBeauty.Model.Requests;
using eNatureBeauty.Model.Requests.InputProducts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eNatureBeauty.WinUI;
using eNatureBeauty.Model.Requests.OutputProducts;
using eNatureBeauty.Model.Requests.Outputs;
using eNatureBeauty.Model.Requests.Orders;
using eNatureBeauty.Model.Enums;

namespace eNatureBeauty.WinUI.Inputs
{
    public partial class frmOutputProductsAdd : Form
    {
        private readonly APIService _productsService = new APIService("products");
        private readonly APIService _ordersService = new APIService("orders");
        private readonly APIService _outputsService = new APIService("outputs");
        private readonly APIService _outputProductsService = new APIService("outputProducts");
        private Model.Inputs _inputs;
        private List<InputProductsAdd> _productsAdd;
        private int generatedSize = 20;
        private Model.Users _loggedUser;
        private bool nextStep = false;
        private Model.Outputs _outputs = new Model.Outputs();

        public frmOutputProductsAdd(Model.Users loggedUser)
        {
            InitializeComponent();
            _productsAdd = new List<InputProductsAdd>();
            _loggedUser = loggedUser;
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            var search = new ProductsSearchRequest()
            {
                ProductName = txtSearch.Text
            };
            var result = await _productsService.Get<List<Model.Products>>(search);
            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.DataSource = result;
        }
        private async void frmInputProductsAdd_Load(object sender, EventArgs e)
        {
            await FilterProducts();
        }

        private async void dgvProducts_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dgvProducts.RowCount != 0)
                await SetMaxQunatityForAdd();
        }

        private bool GetExistedInModel(int productId)
        {
            foreach (var item in _productsAdd)
                if (item.ProductId == productId)
                    return true;

            return false;
        }
        private void SetQuantityFoExisting(int productId)
        {
            var model = _productsAdd.Where(x => x.ProductId == productId).FirstOrDefault();
            model.Quantity += (int)numProducts.Value;
        }
        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (numProducts.Value == 0)
                MessageBox.Show("Not able to add 0 number of products!");

            else
            {
                Model.Products product = (Model.Products)dgvProducts.SelectedRows[0].DataBoundItem;
                var model = await _productsService.GetById<Model.Products>(product.Id);
                if (GetExistedInModel(model.Id))
                    SetQuantityFoExisting(model.Id);

                else
                {
                    InputProductsAdd tmp = new InputProductsAdd
                    {
                        ProductId = model.Id,
                        Name = model.Name,
                        Quantity = (int)numProducts.Value
                    };
                    _productsAdd.Add(tmp);
                }
                dgvProducts.AutoGenerateColumns = false;
                dgvInputProducts.DataSource = null;
                dgvProducts.DataSource = null;
                dgvInputProducts.DataSource = _productsAdd;
                await FilterProducts();
            }
        }

        private async void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProducts.RowCount != 0)
                await SetMaxQunatityForAdd();
        }
        private async Task SetMaxQunatityForAdd()
        {
            Model.Products product = (Model.Products)dgvProducts.SelectedRows[0].DataBoundItem;
            int numToSubs = 0;
            foreach (var item in _productsAdd)
                if (item.ProductId == product.Id)
                    numToSubs = item.Quantity;

            numProducts.Maximum = await Helper.numInStorage(product.Id) - numToSubs;
        }
        private async Task SetMaxQunatityForModify()
        {
            InputProductsAdd product = (InputProductsAdd)dgvInputProducts.SelectedRows[0].DataBoundItem;
            numModify.Maximum = await Helper.numInStorage(product.ProductId);
        }
        private int GetQuantityFromModel(int productId)
        {
            int sum = 0;
            foreach (var item in _productsAdd)
                if (item.ProductId == productId)
                    sum += item.Quantity;

            return sum;
        }
        private async void dgvProducts_Click(object sender, EventArgs e)
        {
            if (dgvProducts.RowCount != 0)
                await SetMaxQunatityForAdd();
        }

        private async void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            await SetMaxQunatityForAdd();
        }
        private async Task FilterProducts()
        {
            var search = new ProductsSearchRequest()
            {
                ProductName = txtSearch.Text
            };
            var result = await _productsService.Get<List<Model.Products>>(search);
            var newList = new List<Model.Products>();
            foreach (var item in result)
            {
                var availableQuantity = await Helper.numInStorage(item.Id) - GetQuantityFromModel(item.Id);
                if (availableQuantity != 0)
                    newList.Add(item);
            }

            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.DataSource = newList;
            numProducts.Value = 0;
            numProducts.Maximum = 0;
        }

        private async void txtFiltered_Click(object sender, EventArgs e)
        {
            await FilterProducts();
        }

        private void dgvInputProducts_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
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
                await FilterProducts();
            }
        }

        private async void dgvInputProducts_Click(object sender, EventArgs e)
        {
            if (dgvInputProducts.RowCount != 0)
                await SetMaxQunatityForModify();
        }

        private async void dgvInputProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvInputProducts.RowCount != 0)
                await SetMaxQunatityForModify();
        }

        private async void dgvInputProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            await SetMaxQunatityForModify();
        }

        private async void btnRemove_Click(object sender, EventArgs e)
        {
            if ((InputProductsAdd)dgvInputProducts.SelectedRows[0].DataBoundItem != null)
            {
                InputProductsAdd product = (InputProductsAdd)dgvInputProducts.SelectedRows[0].DataBoundItem;
                _productsAdd.Remove(product);
                dgvProducts.AutoGenerateColumns = false;
                dgvInputProducts.DataSource = null;
                dgvProducts.DataSource = null;
                dgvInputProducts.DataSource = _productsAdd;
                numModify.Maximum = 0;
                await FilterProducts();
            }
            else
            {
                MessageBox.Show("Nothing selected to remove!");
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (_productsAdd.Count == 0)
            {
                MessageBox.Show("No added products!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Model.Orders _order = new Model.Orders();
                OrdersUpsertRequest orderRequest = new OrdersUpsertRequest
                {
                    Date = DateTime.Now,
                    OrderNumber = Helper.GenerateString(generatedSize),
                    Status = OrderStatusTypes.Created.ToString(),
                    Cancel = false,
                    UserId = _loggedUser.Id
                };
                try
                {
                    _order = await _ordersService.Insert<Model.Orders>(orderRequest);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (_order != null)
                {
                    OutputsUpsertRequest outputsRequest = new OutputsUpsertRequest
                    {
                        Date = DateTime.Now,
                        OrderId = _order.Id,
                        Finished = false,
                        UserId = _loggedUser.Id,
                        ValueWithoutPdv = 0,
                        ValueWithPdv = 0,
                        ReceiveNumber = _order.OrderNumber
                    };
                    try
                    {
                        _outputs = await _outputsService.Insert<Model.Outputs>(outputsRequest);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    await Helper.CalculateInputProductsPrice(_productsAdd);
                    List<OutputProductsUpsertRequest> list = new List<OutputProductsUpsertRequest>();
                    foreach (var item in _productsAdd)
                    {
                        OutputProductsUpsertRequest tmp = new OutputProductsUpsertRequest
                        {
                            OutputId = _outputs.Id,
                            ProductId = item.ProductId,
                            Price = item.Price,
                            Quantity = item.Quantity,
                            Discount = item.Quantity / 2
                        };
                        if (tmp.Quantity > 100)
                            tmp.Discount = 50;
                        if (tmp.Quantity < 20)
                            tmp.Discount = 0;
                        try
                        {
                            await _outputProductsService.Insert<Model.OutputProducts>(tmp);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    await CalculateOutputValue();
                    MessageBox.Show("Success", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }
        private async Task CalculateOutputValue()
        {
            OutputProductsSearchRequest request = new OutputProductsSearchRequest
            {
                OutputId = _outputs.Id
            };
            List<Model.OutputProducts> list = await _outputProductsService.Get<List<Model.OutputProducts>>(request);
            decimal amount = 0;
            foreach (var item in list)
                amount += item.Price - ((item.Price * item.Discount) / 100);

            _outputs.ValueWithoutPdv = amount;
            _outputs.ValueWithPdv = amount - ((amount * 17) / 100);
            try
            {
                await _outputsService.Update<Model.Inputs>(_outputs.Id, _outputs);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
