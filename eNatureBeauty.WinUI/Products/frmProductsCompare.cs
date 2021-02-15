using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eNatureBeauty.WinUI.Products
{
    public partial class frmProductsCompare : Form
    {
        private readonly APIService _products = new APIService("products");
        Model.Products product1 = new Model.Products();
        Model.Products product2 = new Model.Products();
        public frmProductsCompare()
        {
            InitializeComponent();
        }

        private async void cmbFirst_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var idObj = cmbFirst.SelectedValue; //idObj because it is object in service
                if (int.TryParse(idObj.ToString(), out int id))//so we need to parse it 
                {
                    product1 = await _products.GetById<Model.Products>(id);
                }
            }
            catch
            {
                MessageBox.Show("Just a second to load...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void cmbSecond_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var idObj = cmbSecond.SelectedValue; //idObj because it is object in service
                if (int.TryParse(idObj.ToString(), out int id))//so we need to parse it 
                {
                    product2 = await _products.GetById<Model.Products>(id);
                }
            }
            catch
            {
                MessageBox.Show("Just a second to load...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                frmProductsCompareBoth frm2 = new frmProductsCompareBoth(product1, product2);
                Global.shouldEditProduct = false;
                frm2.Show();
            }
        }

        private async void frmProductsCompare_Load(object sender, EventArgs e)
        {
            var result1 = await _products.Get<List<Model.Products>>(null);
            var result2 = await _products.Get<List<Model.Products>>(null);
            //fir
            result1.Insert(0, new Model.Products());
            cmbFirst.DataSource = result1;
            cmbFirst.DisplayMember = "Name";
            cmbFirst.ValueMember = "Id";
            //sec
            result2.Insert(0, new Model.Products());
            cmbSecond.DataSource = result2;
            cmbSecond.DisplayMember = "Name";
            cmbSecond.ValueMember = "Id";
        }

        private void cmbFirst_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                var idObjVP = cmbFirst.SelectedValue; //idObj because it is object in service
                if (int.TryParse(idObjVP.ToString(), out int unitId))//so we need to parse it 
                {
                    if (unitId == 0)
                    {
                        errorProvider1.SetError(cmbFirst, Properties.Resources.Validation_RequiredField);
                        e.Cancel = true;
                    }
                    else
                    {
                        errorProvider1.SetError(cmbFirst, null);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Just a second to load...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cmbSecond_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                var idObjVP = cmbSecond.SelectedValue; //idObj because it is object in service
                if (int.TryParse(idObjVP.ToString(), out int unitId))//so we need to parse it 
                {
                    if (unitId == 0)
                    {
                        errorProvider1.SetError(cmbSecond, Properties.Resources.Validation_RequiredField);
                        e.Cancel = true;
                    }
                    else
                    {
                        errorProvider1.SetError(cmbSecond, null);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Just a second to load...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cmbSecond_Click(object sender, EventArgs e)
        {

        }
    }
}
