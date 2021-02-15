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
    public partial class frmProductsCompareBoth : Form
    {
        private readonly APIService _service = new APIService("products");
        private readonly APIService _outputsService = new APIService("outputs");
        private readonly APIService _outputsProductsService = new APIService("outputProducts");
        private readonly APIService _inputsProductsService = new APIService("inputProducts");
        private readonly APIService _inputsService = new APIService("inputs");
        private readonly APIService _productTypesService = new APIService("productTypes");
        Model.Products _product1 = new Model.Products();
        Model.Products _product2 = new Model.Products();
        int total1 = 0;
        int total2 = 0;
        public frmProductsCompareBoth(Model.Products products1, Model.Products products2)
        {
            InitializeComponent();
            _product1 = products1;
            _product2 = products2;
        }

        private async void frmProductsCompareBoth_Load(object sender, EventArgs e)
        {
            lblTitle1.Text = _product1.Name;
            lblTitle2.Text = _product2.Name;

            txtName.Text = _product1.Name;
            txtName2.Text = _product2.Name;

            txtPrice.Text = _product1.Price.ToString();
            txtPrice2.Text = _product2.Price.ToString();

            await numOfBought();

            if(_product1.Price > _product2.Price) {
                txtPrice.BackColor = Color.Red;
                txtPrice.ForeColor = Color.White;
            }
            if (_product1.Price < _product2.Price)
            {
                txtPrice2.BackColor = Color.Red;
                txtPrice2.ForeColor = Color.White;
            }
            if (_product1.Price == _product2.Price)
            {
                txtPrice.BackColor = Color.White;
                txtPrice2.BackColor = Color.White;
            }

            if (total1 > total2)
            {
                txtBought.BackColor = Color.Red;
                txtBought.ForeColor = Color.White;
            }
            if (total1 < total2)
            {
                txtBought2.BackColor = Color.Red;
                txtBought2.ForeColor = Color.White;
            }
            if(total1 == total2)
            {
                txtBought.BackColor = Color.White;
                txtBought2.BackColor = Color.White;
            }
        }
        private async Task numOfBought()
        {

            total2 = 0;
            total1 = 0;
            List<Model.OutputProducts> outputProducts = await _outputsProductsService.Get<List<Model.OutputProducts>>(null);
            foreach (var item in outputProducts)
            {
                if (item.ProductId == _product1.Id)
                    total1 += item.Quantity;
                if (item.ProductId == _product2.Id)
                    total2 += item.Quantity;

            }
            txtBought.Text = total1.ToString();
            txtBought2.Text = total2.ToString();
        }
    }
}
