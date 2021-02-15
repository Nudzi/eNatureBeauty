using eNatureBeauty.Model.Requests;
using eNatureBeauty.WinUI.Ingredients;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace eNatureBeauty.WinUI.Products
{
    public partial class frmProductAdd : Form
    {
        private readonly APIService _productTypes = new APIService("productTypes");
        private readonly APIService _units = new APIService("units");
        private readonly APIService _products = new APIService("products");
        public frmProductAdd()
        {
            InitializeComponent();
        }

        private async Task LoadProductTypes()
        {
            var result = await _productTypes.Get<List<Model.ProductTypes>>(null);
            result.Insert(0, new Model.ProductTypes());//first empty record
            cmbProductTypes.DataSource = result;
            cmbProductTypes.DisplayMember = "Name";
            cmbProductTypes.ValueMember = "Id";
        }
        private async Task LoadUnits()
        {
            var result = await _units.Get<List<Model.Units>>(null);
            result.Insert(0, new Model.Units());//first empty record
            //cmbUnits.DataSource = result;
            //cmbUnits.DisplayMember = "Name";
            //cmbUnits.ValueMember = "Id";
        }
        private async void cmbProductTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            //var idObj = cmbProductTypes.SelectedValue; //idObj because it is object in service
            //if (int.TryParse(idObj.ToString(), out int id))//so we need to parse it 
            //{
            //    await LoadProducts(id);
            //}
        }
        private async Task LoadProducts(int productTypesId)
        {
            var result = await _products.Get<List<Model.Products>>(new ProductsSearchRequest()//because we have filter as
            {                                                                                   //object, but we need our one
                ProductTypeId = productTypesId
            });
            //dgvProducts.DataSource = result;
        }
        ProductsUpsertRequest request = new ProductsUpsertRequest();//has to go public because there is another button that will use made request
        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateChildren())
                {
                    var idObjVP = cmbProductTypes.SelectedValue; //idObj because it is object in service
                    if (int.TryParse(idObjVP.ToString(), out int productTypeId))//so we need to parse it 
                    {
                        request.ProductTypeId = productTypeId;
                    }

                    request.Status = chbStatus.Checked;
                    request.Name = txtName.Text;
                    request.Code = txtCode.Text;
                    request.Description = txtDesc.Text;
                    request.Price = decimal.Parse(txtPrice.Text);
                    if (txtImageInput.Text == "")
                    {
                        var filename = "";
                        var file = File.ReadAllBytes(filename);//to get bytes from our filename
                        request.Image = file;
                        request.ImageThumb = file;
                        txtImageInput.Text = filename;
                        Image img = Image.FromFile(filename);
                        pbUpload.Image = img;
                    }
                    var product = await _products.Insert<Model.Products>(request);
                    MessageBox.Show("Sucessfully added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    frmIngredientsProduct frm = new frmIngredientsProduct(product);
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private async void frmProducts_Load(object sender, EventArgs e)
        {
            await LoadProductTypes();
            //await LoadUnits();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                var filename = openFileDialog.FileName;
                var file = File.ReadAllBytes(filename);//to get bytes from our filename
                request.Image = file;
                request.ImageThumb = file;
                txtImageInput.Text = filename;
                Image img = Image.FromFile(filename);
                pbUpload.Image = img;
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

        private void cmbProductTypes_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var idObjVP = cmbProductTypes.SelectedValue; //idObj because it is object in service
            if (int.TryParse(idObjVP.ToString(), out int unitId))//so we need to parse it 
            {
                if (unitId == 0)
                {
                    errorProvider1.SetError(cmbProductTypes, Properties.Resources.Validation_RequiredField);
                    e.Cancel = true;
                }
                else
                {
                    errorProvider1.SetError(cmbProductTypes, null);
                }
            }
        }

        private void txtImageInput_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtImageInput.Text))
            {
                errorProvider1.SetError(txtImageInput, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtImageInput, null);
            }
        }

        private void txtCode_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCode.Text))
            {
                errorProvider1.SetError(txtCode, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtCode, null);
            }
        }
    }
}
