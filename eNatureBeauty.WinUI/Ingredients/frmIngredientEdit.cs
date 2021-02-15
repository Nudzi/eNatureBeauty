using eNatureBeauty.Model.Requests;
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
    public partial class frmIngredientEdit : Form
    {
        private readonly APIService _ingredientsIngredientTypes = new APIService("ingredientsIngredientTypes");
        private readonly APIService _service = new APIService("ingredients");
        private readonly APIService _unitsService = new APIService("units");
        private readonly APIService _ingredientTypes = new APIService("ingredientTypes");
        private Model.Ingredients _ingredient;
        public frmIngredientEdit(Model.Ingredients ingredients)
        {
            InitializeComponent();
            _ingredient = ingredients;
        }

        private async void frmIngredientEdit_Load(object sender, EventArgs e)
        {
            await LoadUnits();
            txtName.Text = _ingredient.Name;
        }

        private async Task LoadUnits()
        {
           var units = await _unitsService.GetById<Model.Units>(_ingredient.UnitID);
           txtUnitName.Text = units.Name;
 
            var result = await _ingredientsIngredientTypes.Get<List<Model.IngredientsIngredientTypes>>(new IngredientsSearchRequest()//because we have filter as
            {                                                                                   //object, but we need our one
                IngredientID = _ingredient.Id
            });
            var result3 = new List<Model.IngredientTypes>();
            var result2 = await _ingredientTypes.Get<List<Model.IngredientTypes>>("");
            foreach (var item in result)
            {
                foreach (var item2 in result2)
                {
                    if (item.IngredientTypeID == item2.ID)
                    {
                        result3.Add(item2);
                    }
                }
            }

            foreach (var item in result3)
            {
                lvTypes.Items.Add(item.Name);//if name is a string property
            }
            Controls.Add(lvTypes);
            lvTypes.GridLines = true;
            lvTypes.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                _ingredient.Name = txtName.Text;

                IngredientsUpsertRequest request = new IngredientsUpsertRequest
                {
                    Description = _ingredient.Description,
                    Id = _ingredient.Id,
                    Name = _ingredient.Name,
                    Status = _ingredient.Status,
                    UnitID = _ingredient.UnitID
                };

                try
                {
                    _ingredient = await _service.Update<Model.Ingredients>(_ingredient.Id, request);
                    MessageBox.Show("Success");
                    Close();
                }
                catch
                {
                    MessageBox.Show("Error");
                }
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if ((bool)!_ingredient.Status)
                    throw new Exception("Ingredient is already inactive!");

                IngredientsUpsertRequest request = new IngredientsUpsertRequest
                {
                    Description = _ingredient.Description,
                    Id = _ingredient.Id,
                    Name = _ingredient.Name,
                    Status = false,
                    UnitID = _ingredient.UnitID
                };

                await _service.Update<Model.Ingredients>(_ingredient.Id, request);
                MessageBox.Show("Success, ingredient is inactive!");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
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
