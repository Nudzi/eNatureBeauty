using eNatureBeauty.Model.Requests;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace eNatureBeauty.WinUI.Users
{
    public partial class frmUsers : Form
    {
        private readonly APIService _apiService = new APIService("users");
        public frmUsers()
        {
            InitializeComponent();
        }

        private async void btnShow_Click(object sender, EventArgs e)
        {
            var search = new UsersSearchRequest()
            {
                FirstName = txtSearch.Text
            };
            var result = await _apiService.Get<List<Model.Users>>(search);
            dgvUsers.AutoGenerateColumns = false;
            dgvUsers.DataSource = result;
        }


        private void dgvUsers_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try { 
            var id = dgvUsers.SelectedRows[0].DataBoundItem;
            Global.shouldEditRoles = false;
            frmUsersDetails frm = new frmUsersDetails(id as Model.Users);
            frm.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Nothing selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try { 
            var id = dgvUsers.SelectedRows[0].DataBoundItem;
            Global.shouldEditRoles = false;
            frmUsersDetails frm = new frmUsersDetails(id as Model.Users);
            frm.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Nothing selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
