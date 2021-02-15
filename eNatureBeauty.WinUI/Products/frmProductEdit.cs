using eNatureBeauty.Model.Requests.Outputs;
using eNatureBeauty.WinUI.Ingredients;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eNatureBeauty.WinUI.Products
{
    public partial class frmProductEdit : Form
    {
        private readonly APIService _service = new APIService("products");
        private readonly APIService _outputsService = new APIService("outputs");
        private readonly APIService _outputsProductsService = new APIService("outputProducts");
        private readonly APIService _inputsProductsService = new APIService("inputProducts");
        private readonly APIService _inputsService = new APIService("inputs");
        private readonly APIService _productTypesService = new APIService("productTypes");
        private Model.Products _product;
        private readonly string NO_CONTENT = "NO_CONTENT";

        public frmProductEdit(Model.Products product)
        {
            InitializeComponent();
            _product = product;
        }
        private async Task ReturnTypeName()
        {
            var productsTypes = await _productTypesService.GetById<Model.ProductTypes>(_product.ProductTypeId);
            txtType.Text = productsTypes.Name;
        }
        private async Task numOfBought()
        {
            int total = 0;
            
            List<Model.OutputProducts> outputProducts = await _outputsProductsService.Get<List<Model.OutputProducts>>("");
            foreach (var item in outputProducts)
            {
                if (item.ProductId == _product.Id)
                    total += item.Quantity;

            }
            txtBought.Text = total.ToString();
        }
        private async Task numInStorage()
        {
            int total = 0;
            List<Model.InputProducts> inputProducts = await _inputsProductsService.Get<List<Model.InputProducts>>("");
            foreach (var item in inputProducts)
            {
                if (item.ProductId == _product.Id)
                    total += item.Quantity;

            }
            var numberMy = int.Parse(txtBought.Text);
            total -= numberMy;
            txtInStorage.Text = total.ToString();
        }
        private async void frmProductEdit_Load(object sender, EventArgs e)
        {
            if (!Global.shouldEditProduct)
            {
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                txtName.Enabled = false;
                txtDesc.Enabled = false;
                txtPrice.Enabled = false;
            }
            if (Global.shouldEditProduct)
            {
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                txtName.Enabled = true;
                txtDesc.Enabled = true;
                txtPrice.Enabled = true;
            }
            await ReturnTypeName();
            if (_product != null)
            {
                lblTitle.Text = _product.Name;
                txtName.Text = _product.Name;
                if (_product.Description == "" || _product.Description == NO_CONTENT)
                    txtDesc.Text = NO_CONTENT;
                else
                    txtDesc.Text = _product.Description;

                txtPrice.Value = _product.Price;
                await numOfBought();
                await numInStorage();
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                try
                {
                    _product.Name = txtName.Text;
                    _product.Code = _product.Code;
                    _product.Description = txtDesc.Text;
                    _product.Price = (txtPrice.Value);

                    await _service.Update<Model.Products>(_product.Id, _product);
                    MessageBox.Show("Success");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnIngredients_Click(object sender, EventArgs e)
        {
            frmIngredients frm = new frmIngredients(_product);
            frm.Show();
        }

        private void btnStatus_Click(object sender, EventArgs e)
        {
            frmProductStatus frm = new frmProductStatus(_product);
            frm.Show();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if ((bool)!_product.Status)
                    throw new Exception("Product is already inactive!");

                _product.Status = false;
                await _service.Update<Model.Products>(_product.Id, _product);
                MessageBox.Show("Success, product is inactive!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                errorProvider1.SetError(txtName, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtName, null);
            }
        }
    }
}
