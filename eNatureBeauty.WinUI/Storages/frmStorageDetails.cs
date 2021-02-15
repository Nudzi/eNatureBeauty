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

namespace eNatureBeauty.WinUI.Storages
{
    public partial class frmStorageDetails : Form
    {
        private readonly APIService _service = new APIService("storages");
        private readonly APIService _inputsService = new APIService("inputs");
        private Model.Storages _storage;
        public frmStorageDetails(Model.Storages storage)
        {
            InitializeComponent();
            _storage = storage;
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

        private void txtAddress_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                errorProvider1.SetError(txtAddress, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtAddress, null);
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateChildren())
                {
                    
                        var request = new StoragesUpsertRequest()
                    {
                        Description = txtDesc.Text,
                        Name = txtName.Text,
                        Address = txtAddress.Text
                    };

                    if (_storage == null)
                    {
                        await _service.Insert<Model.Storages>(request);
                        MessageBox.Show("Succesfully added!");
                        this.Close();
                    }
                    else
                    {
                        request.Id = _storage.Id;
                        await _service.Update<Model.Storages>(_storage.Id ,request);
                        MessageBox.Show("Succesfully updated!");
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmStorageDetails_Load(object sender, EventArgs e)
        {
            if (_storage == null)
            {
                btnDelete.Visible = false;
            }
            if (_storage != null)
            {
                txtAddress.Text = _storage.Address;
                txtDesc.Text = _storage.Description;
                txtName.Text = _storage.Name;
                btnDelete.Visible = true;
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var inputs = await _inputsService.Get<List<Model.Inputs>>(null);

                foreach (var item in inputs)
                {
                    if (item.StorageId == _storage.Id)
                        throw new Exception("Can not delete storage beacause it is in use by input products!");
                }
                await _service.Delete<Model.Storages>(_storage.Id);
                MessageBox.Show("Succesfully deleted!");
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
