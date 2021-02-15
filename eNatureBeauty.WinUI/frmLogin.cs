using eNatureBeauty.Model.Enums;
using Flurl.Http;
using System;
using System.Windows.Forms;
using eNatureBeauty.WinUI.Index;
using eNatureBeauty.WinUI.Users;

namespace eNatureBeauty.WinUI
{
    public partial class frmLogin : Form
    {
        protected APIService _service = new APIService("users");
        protected APIService _userTypesService = new APIService("userTypes");
        Model.UserTypes role = null;
        public frmLogin()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            APIService.userName = txtUserName.Text;
            APIService.password = txtPassword.Text;
            try
            {
                if (string.IsNullOrEmpty(txtUserName.Text) || string.IsNullOrEmpty(txtPassword.Text))
                {
                    MessageBox.Show("All fields are required! Try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                else
                {
                    //var request = new UserLoginRequest
                    //{
                    //    UserName = txtUserName.Text,
                    //    Password = txtPassword.Text
                    //};
                    //var url = $"{Properties.Settings.Default.APIUrl}/users/login";
                    //await url.GetJsonAsync(request).ReceiveJson<Model.Users>();
                    //await _service.Get<dynamic>(request);
                    Model.Users user = await _service.Authentication<Model.Users>(txtUserName.Text, txtPassword.Text);

                    checkUserType(user);
                    MessageBox.Show("Welcome:\n " + user.FirstName + " " + user.LastName);
                    DialogResult = DialogResult.OK;
                    this.Hide();
                    if (Global.Admin)
                    {
                        frmIndex frm = new frmIndex();
                        frm.Show();
                    }
                    if (Global.User)
                    {
                        MessageBox.Show("Wrong username or password", "You do not have permissions!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (Global.Employee)
                    {
                        frmIndexEmployee frm = new frmIndexEmployee(user);
                        frm.Show();
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Wrong username or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private async void checkUserType(Model.Users user)
        {
            int userTypeFirst = 0;
            if (user != null)
            {
                Global.LoggedUser = user;

                foreach (var item in Global.LoggedUser.UserTypes)
                {
                    if (item.IsActive)
                        userTypeFirst = item.UserTypeId;
                }
                role = await _userTypesService.GetById<Model.UserTypes>(userTypeFirst);
                if (role.Id == (int)UserTypes.Admin)
                    Global.Admin = true;
                //if (role.Id == (int)UserTypes.Client)
                //    Global.Client = true;
                if (role.Id == (int)UserTypes.Employee)
                    Global.Employee = true;
                if (role.Id == (int)UserTypes.User)
                    Global.User = true;
            }
        }

        private void linkNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmUsersDetails frm = new frmUsersDetails(null, true);
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }
    }
}
