using eNatureBeauty.Model.Requests;
using eNatureBeauty.Model.Requests.ProductsIngredients;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eNatureBeauty.WinUI.Ingredients
{
    public partial class frmIngredientsProduct : Form
    {
        private readonly APIService _ingredientTypes = new APIService("ingredientTypes");
        private readonly APIService _productsIngredients = new APIService("productsIngredients");
        private readonly APIService _ingredientsIngredientTypes = new APIService("ingredientsIngredientTypes");
        private readonly APIService _ingredients = new APIService("ingredients");
        private Model.Products _product;
        private List<ProductIngredientAdd> _ingredientAdd = new List<ProductIngredientAdd>();
        //private List<ProductIngredientAdd> _ingredientSee = new List<ProductIngredientAdd>();
        public frmIngredientsProduct(Model.Products product)
        {
            InitializeComponent();
            _product = product;
        }

        private async void frmIngredientsProduct_Load(object sender, EventArgs e)
        {
            await LoadIngredients();
        }
        private async Task LoadIngredients()
        {
            var search = new IngredientsSearchRequest()
            {
                Name = txtSearch.Text
            };
            var result = await _ingredients.Get<List<Model.Ingredients>>(search);
            dgvIngredients.AutoGenerateColumns = false;
            dgvIngredients.DataSource = result;
        }

        private bool GetExistedInModel(int ingredientId)
        {
            foreach (var item in _ingredientAdd)
                if (item.IngredientId == ingredientId)
                    return true;

            return false;
        }
        private void SetQuantityFoExisting(int id)
        {
            var model = _ingredientAdd.Where(x => x.IngredientId == id).FirstOrDefault();
            model.Measure += (int)numMeasure.Value;
        }
        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (numMeasure.Value == 0)
                MessageBox.Show("Not able to add 0 measure number of ingredient!");

            else
            {
                Model.Ingredients ingredients = (Model.Ingredients)dgvIngredients.SelectedRows[0].DataBoundItem;
                var model = await _ingredients.GetById<Model.Ingredients>(ingredients.Id);
                if (GetExistedInModel(model.Id))
                    SetQuantityFoExisting(model.Id);

                else
                {
                    ProductIngredientAdd tmp = new ProductIngredientAdd
                    {
                        ProductId = _product.Id,
                        IngredientId = model.Id,
                        Measure = (int)numMeasure.Value,
                        Name = model.Name
                    };
                    _ingredientAdd.Add(tmp);
                }
                dgvIngredients.AutoGenerateColumns = false;
                dgvIngredientsProducts.DataSource = null;
                dgvIngredients.DataSource = null;
                dgvIngredientsProducts.DataSource = _ingredientAdd;
                await FilterProducts();
            }
        }
        private async Task FilterProducts()
        {
            var search = new IngredientsSearchRequest()
            {
                Name = txtSearch.Text
            };
            var result = await _ingredients.Get<List<Model.Ingredients>>(search);
            dgvIngredients.AutoGenerateColumns = false;
            dgvIngredients.DataSource = result;
            numMeasure.Value = 0;
        }
        private async void txtFiltered_Click(object sender, EventArgs e)
        {
            await LoadIngredients();
        }

        private async void btnModify_Click(object sender, EventArgs e)
        {
            if (numModify.Value == 0)
                MessageBox.Show("Not able to add 0 number of ingredient!");
            else
            {
                ProductIngredientAdd product = (ProductIngredientAdd)dgvIngredientsProducts.SelectedRows[0].DataBoundItem;
                var model = _ingredientAdd.Where(x => x.IngredientId == product.IngredientId).FirstOrDefault();
                model.Measure = (int)numModify.Value;

                dgvIngredients.AutoGenerateColumns = false;
                dgvIngredientsProducts.DataSource = null;
                dgvIngredients.DataSource = null;
                dgvIngredientsProducts.DataSource = _ingredientAdd;
                await FilterProducts();
            }
        }

        private async void btnRemove_Click(object sender, EventArgs e)
        {
            if ((ProductIngredientAdd)dgvIngredientsProducts.SelectedRows[0].DataBoundItem != null)
            {
                ProductIngredientAdd product = (ProductIngredientAdd)dgvIngredientsProducts.SelectedRows[0].DataBoundItem;
                _ingredientAdd.Remove(product);

                dgvIngredients.AutoGenerateColumns = false;
                dgvIngredientsProducts.DataSource = null;
                dgvIngredients.DataSource = null;
                dgvIngredientsProducts.DataSource = _ingredientAdd;
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
            if (_ingredientAdd.Count == 0)
            {
                MessageBox.Show("Error, no selected ingredients for product!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                foreach (var item in _ingredientAdd)
                {
                    ProductsIngredientsUpsertRequest request = new ProductsIngredientsUpsertRequest
                    {
                        IngredientID = item.IngredientId,
                        ProductID = _product.Id,
                        Measure = item.Measure
                    };

                    try
                    {
                        await _productsIngredients.Insert<Model.ProductsIngredients>(request);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                MessageBox.Show("Success", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}