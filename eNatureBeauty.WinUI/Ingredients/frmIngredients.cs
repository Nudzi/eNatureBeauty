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
    public partial class frmIngredients : Form
    {
        private readonly APIService _ingredientTypes = new APIService("ingredientTypes");
        private readonly APIService _productsIngredients = new APIService("productsIngredients");
        private readonly APIService _ingredientsIngredientTypes = new APIService("ingredientsIngredientTypes");
        private readonly APIService _ingredients = new APIService("ingredients");
        private Model.Products _product;
        public frmIngredients(Model.Products product = null)
        {
            InitializeComponent();
            _product = product;
        }
        private void dgvIngredients_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try { 
            var id = dgvIngredients.SelectedRows[0].DataBoundItem;
            frmIngredientEdit frm = new frmIngredientEdit(id as Model.Ingredients);
            frm.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Nothing selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        List<Model.Ingredients> finalIngredients = new List<Model.Ingredients>();
        List<Model.Ingredients> filteredIngredients = new List<Model.Ingredients>();
        private async Task LoadIngredinets(int ingredinetTypeId=0)
        {
            filteredIngredients = await _ingredients.Get<List<Model.Ingredients>>("");
            if (_product == null)
            {
                List<Model.IngredientsIngredientTypes> firstIngredients;
                if (ingredinetTypeId != 0)
                {
                    firstIngredients = await _ingredientsIngredientTypes.Get<List<Model.IngredientsIngredientTypes>>(new IngredientsSearchRequest()//because we have filter as
                    {                                                                                   //object, but we need our one
                        IngredientTypeID = ingredinetTypeId
                    });
                }
                else
                {
                    firstIngredients = await _ingredientsIngredientTypes.Get<List<Model.IngredientsIngredientTypes>>("");
                }
                finalIngredients = new List<Model.Ingredients>();
                foreach (var item in firstIngredients)
                {
                    foreach (var item2 in filteredIngredients)
                    {
                        if (item.IngredientID == item2.Id)
                        {
                            finalIngredients.Add(item2);
                        }
                    }
                }
                List<Model.Ingredients> list = new List<Model.Ingredients>(finalIngredients.Distinct());
                dgvIngredients.AutoGenerateColumns = false;
                dgvIngredients.DataSource = list;
            }
            else
            {
                cmbIngredientTypes.Enabled = false;
                List<Model.ProductsIngredients> result;
                    result = await _productsIngredients.Get<List<Model.ProductsIngredients>>(new ProductsIngredientsSearchRequest()
                    {                                                                                   
                        ProductID = _product.Id
                    });
                finalIngredients = new List<Model.Ingredients>();
                foreach (var item in result)
                {
                    foreach (var item2 in filteredIngredients)
                    {
                        if (item.IngredientID == item2.Id)
                        {
                            finalIngredients.Add(item2);
                        }
                    }
                }
                dgvIngredients.AutoGenerateColumns = false;
                dgvIngredients.DataSource = finalIngredients;
            }
        }
        private async Task LoadIngredientTypes()
        {
            var result = await _ingredientTypes.Get<List<Model.IngredientTypes>>(null);
            result.Insert(0, new Model.IngredientTypes("All"));//first empty record
            cmbIngredientTypes.DataSource = result;
            cmbIngredientTypes.DisplayMember = "Name";
            cmbIngredientTypes.ValueMember = "Id";
        }

        private async void frmIngredients_Load(object sender, EventArgs e)
        {
            await LoadIngredinets();
            await LoadIngredientTypes();
        }

        private async void cmbIngredientTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idObj = cmbIngredientTypes.SelectedValue; //idObj because it is object in service
            if (int.TryParse(idObj.ToString(), out int id))//so we need to parse it 
            {
                await LoadIngredinets(id);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var query = new List<Model.Ingredients>();

            if (_product == null)
            {
                foreach (var item in filteredIngredients)
                {
                    if (item.Name.ToLower().StartsWith(txtSearch.Text.ToLower()))
                    {
                        query.Add(item);
                    }
                }
            }
            else
            {
                foreach (var item in finalIngredients)
                {
                    if (item.Name.ToLower().StartsWith(txtSearch.Text.ToLower()))
                    {
                        query.Add(item);
                    }
                }
            }
            dgvIngredients.AutoGenerateColumns = false;
            dgvIngredients.DataSource = query;
        }

        private void dgvIngredients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try { 
            var id = dgvIngredients.SelectedRows[0].DataBoundItem;
            frmIngredientEdit frm = new frmIngredientEdit(id as Model.Ingredients);
            frm.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Nothing selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
