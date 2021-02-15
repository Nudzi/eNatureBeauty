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
    public partial class frmStorages : Form
    {
        private readonly APIService _service = new APIService("storages");
        public frmStorages()
        {
            InitializeComponent();
        }

        private void dgvStorages_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try { 
            var id = dgvStorages.SelectedRows[0].DataBoundItem;
            frmStorageDetails frm = new frmStorageDetails(id as Model.Storages);
            frm.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Nothing selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void frmStorages_Load(object sender, EventArgs e)
        {
            await LoadStorages();
        }
        private async Task LoadStorages()
        {
            StoragesSearchRequest request = new StoragesSearchRequest
            {
                Name = txtSearch.Text
            };
            List<Model.Storages> result = await _service.Get<List<Model.Storages>>(request);//because we have filter as
            dgvStorages.AutoGenerateColumns = false;
            dgvStorages.DataSource = result;
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            await LoadStorages();
        }
    }
}
