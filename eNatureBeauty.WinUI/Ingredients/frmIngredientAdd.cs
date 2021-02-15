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
    public partial class frmIngredientAdd : Form
    {
        private readonly APIService _service = new APIService("ingredients");
        private readonly APIService _units = new APIService("units");
        private readonly APIService _ingredientTypesService = new APIService("ingredientTypes");
        public frmIngredientAdd()
        {
            InitializeComponent();
        }
        private async Task LoadTypes()
        {
            var ingredientTypes = await _ingredientTypesService.Get<List<Model.IngredientTypes>>(null);
            clbTypes.DataSource = ingredientTypes;
            clbTypes.DisplayMember = "Name";
        }

        private async void frmIngredientAdd_Load(object sender, EventArgs e)
        {
            await LoadTypes();
            await LoadUnits();
        }
        private async Task LoadUnits()
        {
            var result = await _units.Get<List<Model.Units>>(null);
            result.Insert(0, new Model.Units());//first empty record
            cblUnits.DataSource = result;
            cblUnits.DisplayMember = "Name";
            cblUnits.ValueMember = "Id";
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateChildren())
                {
                    List<int> ingredientstypes = new List<int>();
                    ingredientstypes = clbTypes.CheckedItems.Cast<Model.IngredientTypes>().Select(x => x.ID).ToList();
                    var request = new IngredientsUpsertRequest()
                    {
                        Description = txtDesc.Text,
                        Name = txtName.Text,
                        Status = cbStatus.Checked,
                        UnitID = 1,
                        IngredientsTypes = ingredientstypes
                    };

                    var idObjVP = cblUnits.SelectedValue; //idObj because it is object in service
                    if (int.TryParse(idObjVP.ToString(), out int unitId))//so we need to parse it 
                    {
                        request.UnitID = unitId;
                    }

                    await _service.Insert<Model.Ingredients>(request);
                    MessageBox.Show("Succesfully added!");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void clbTypes_Validating(object sender, CancelEventArgs e)
        {
            List<int> ingredientstypes = new List<int>();
            ingredientstypes = clbTypes.CheckedItems.Cast<Model.IngredientTypes>().Select(x => x.ID).ToList();

            if (ingredientstypes.Count == 0)
            {
                errorProvider1.SetError(clbTypes, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(clbTypes, null);
            }
        }

        private void cblUnits_Validating(object sender, CancelEventArgs e)
        {
            var idObjVP = cblUnits.SelectedValue; //idObj because it is object in service
            if (int.TryParse(idObjVP.ToString(), out int unitId))//so we need to parse it 
            {
                if (unitId == 0)
                {
                    errorProvider1.SetError(cblUnits, Properties.Resources.Validation_RequiredField);
                    e.Cancel = true;
                }
                else
                {
                    errorProvider1.SetError(cblUnits, null);
                }
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
