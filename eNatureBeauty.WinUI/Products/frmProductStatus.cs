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
    public partial class frmProductStatus : Form
    {
        private readonly APIService _service = new APIService("products");
        private readonly APIService _reviewsService = new APIService("reviews");
        private readonly APIService _wishlistsService = new APIService("wishlists");
        private readonly APIService _productTypesService = new APIService("productTypes");
        private Model.Products _product;
        public frmProductStatus(Model.Products product)
        {
            InitializeComponent();
            _product = product;
        }

        private async Task ReturnTypeName()
        {
            var productsTypes = await _productTypesService.GetById<Model.ProductTypes>(_product.ProductTypeId);
            txtType.Text = productsTypes.Name;
        }
        private async Task ReturnInWishlists()
        {
            var wishlists = await _wishlistsService.Get<List<Model.Wishlists>>(_product.Id);
            List<Model.Wishlists> result = new List<Model.Wishlists>();
            foreach (var item in wishlists)
            {
                if(item.ProductId == _product.Id)
                {
                    result.Add(item);
                }
            }
            txtInWishlists.Text = result.Count().ToString();
        }
        private async Task ReturnReviewed()
        {
            var reviewed = await _reviewsService.Get<List<Model.Reviews.Reviews>>(_product.Id);
            List<Model.Reviews.Reviews> result = new List<Model.Reviews.Reviews>();
            foreach (var item in reviewed)
            {
                if (item.ProductId == _product.Id)
                {
                    result.Add(item);
                }
            }
            txtReviewed.Text = result.Count().ToString();
            if (txtReviewed.Text.Equals("0")) {
                txtAverage.Text = "0";
            }
            else {
                txtAverage.Text = Math.Round((Double)result.Average(x => x.Review), 2).ToString();
            }
        }
        private async void frmProductStatus_Load(object sender, EventArgs e)
        {
            await ReturnTypeName();
            await ReturnInWishlists();
            await ReturnReviewed();
            txtName.Text = _product.Name;
        }
    }
}
