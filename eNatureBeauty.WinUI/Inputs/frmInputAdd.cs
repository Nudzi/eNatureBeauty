using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eNatureBeauty.Model.Requests.Inputs;

namespace eNatureBeauty.WinUI.Inputs
{
    public partial class frmInputAdd : Form
    {
        private readonly APIService _storagesService = new APIService("storages");
        private readonly APIService _inputsService = new APIService("inputs");
        private int generatedSize = 19;
        private Model.Users _loggedUser;
        private Model.Users _user;
        public frmInputAdd(Model.Users loggedUser)
        {
            InitializeComponent();
            _loggedUser = loggedUser;
        }

        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idObj = cmbStorages.SelectedValue; //idObj because it is object in service
            if (int.TryParse(idObj.ToString(), out int id))//so we need to parse it 
            {
            }
        }

        private async void frmInputAdd_Load(object sender, EventArgs e)
        {
            await LoadStorages();
            numPDV.Value = 17;
        }
        private async Task LoadStorages()
        {
            var result = await _storagesService.Get<List<Model.Storages>>(null);
            cmbStorages.DataSource = result;
            cmbStorages.DisplayMember = "Name";
            cmbStorages.ValueMember = "Id";
        }

        private async void btnNext_Click(object sender, EventArgs e)
        {
            var idObjVP = cmbStorages.SelectedValue; //idObj because it is object in service
            int.TryParse(idObjVP.ToString(), out int storageId);//so we need to parse it 
            var request = new InputsUpsertRequest()
            {
                InvoiceNumber = Helper.GenerateString(generatedSize),
                InvoiceAmount = 0,
                Pdv = numPDV.Value,
                Note = txtNote.Text,
                Date = DateTime.Now,
                StorageId = storageId,
                UserId = _loggedUser.Id
            };
            try
            {
                Model.Inputs input = await _inputsService.Insert<Model.Inputs>(request);
                this.Hide();
                frmInputsProductsAdd frm = new frmInputsProductsAdd(input);
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
