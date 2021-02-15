using eNatureBeauty.Model.Enums;
using eNatureBeauty.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eNatureBeauty.WinUI.Users
{
    public partial class frmUsersDetails : Form
    {
        private readonly APIService _service = new APIService("users");
        private readonly APIService _userTypesService = new APIService("userTypes");
        private Model.Users _user;
        private bool _token;
        public frmUsersDetails(Model.Users user = null, bool token = false)
        {
            InitializeComponent();
            _user = user;
            _token = token;
        }

        private Boolean checkPhonenumber(string telephoneNumber)
        {
            foreach (char item in telephoneNumber)
            {
                if (!Char.IsDigit(item))
                    return false;
            }
            return true;
        }
        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!checkPhonenumber(txtTelephone.Text))
            {
                MessageBox.Show("Telephone number contains letters!");
                return;
            }

            if (ValidateChildren())
            {
                List<int> usertypes = new List<int>();
                if (_token)
                    usertypes.Add((int)UserTypes.User);
                else
                    usertypes = cblUserTypes.CheckedItems.Cast<Model.UserTypes>().Select(x => x.Id).ToList();
                
                var request = new UsersInsertRequest()
                {
                    Email = txtEmail.Text,
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    UserName = txtUserName.Text,
                    Telephone = txtTelephone.Text,
                    Password = txtPassword.Text,
                    PasswordConfirmation = txtPasswordConfirmation.Text,
                    Status = cbStatus.Checked,
                    UserTypes = usertypes
                };

                if (_user == null)
                {
                    try
                    {
                        await _service.Insert<Model.Users>(request);
                        MessageBox.Show("Succesfully added!");
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    request.Id = _user.Id;
                    try
                    {
                        await _service.Update<Model.Users>(_user.Id, request);
                        MessageBox.Show("Succesfully updated!");
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private async void frmUsersDetails_Load(object sender, EventArgs e)
        {
            await LoadUloge();
            if (Global.shouldEditRoles == false)
                gbUserTypes.Visible = false;

            if (Global.shouldEditRoles == true)
                gbUserTypes.Visible = true;

            if (_user != null)
            {
                txtEmail.Text = _user.Email;
                txtFirstName.Text = _user.FirstName;
                txtLastName.Text = _user.LastName;
                txtTelephone.Text = _user.Telephone;
                txtUserName.Text = _user.UserName;
                cbStatus.Checked = (bool)_user.Status;
            }
        }

        private void txtFirstName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                errorProvider.SetError(txtFirstName, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtFirstName, null);
            }
        }

        private void txtLastName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                errorProvider.SetError(txtLastName, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtLastName, null);
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                errorProvider.SetError(txtEmail, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtEmail, null);
            }
        }

        private void txtTelephone_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTelephone.Text))
            {
                errorProvider.SetError(txtTelephone, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtTelephone, null);
            }
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                errorProvider.SetError(txtUserName, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtUserName, null);
            }
        }
        private async Task LoadUloge()
        {
            var userTypes = await _userTypesService.Get<List<Model.UserTypes>>(null);
            cblUserTypes.DataSource = userTypes;
            cblUserTypes.DisplayMember = "Name";
        }
    }
}
