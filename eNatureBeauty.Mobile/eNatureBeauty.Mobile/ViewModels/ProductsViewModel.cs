using eNatureBeauty.Mobile.Services;
using eNatureBeauty.Model;
using eNatureBeauty.Model.Requests;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eNatureBeauty.Mobile.ViewModels
{
    public class ProductsViewModel : BaseViewModel
    {
        private readonly APIService _service = new APIService("products");
        private readonly APIService _productTypesService = new APIService("productTypes");
        public ProductsViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }

        public ObservableCollection<Products> ProductsList { get; set; } = new ObservableCollection<Products>();
        public ObservableCollection<ProductTypes> ProductTypesList { get; set; } = new ObservableCollection<ProductTypes>();
        ProductTypes _selectedProductTypes = null; 
        public ICommand InitCommand { get; set; }
        public Users User { get; set; }

        public ProductTypes SelectedProductTypes
        {
            get { return _selectedProductTypes; }
            set
            {
                SetProperty(ref _selectedProductTypes, value);
                if (value != null)
                {
                    InitCommand.Execute(null);
                }

            }
        }
        public async Task Init()
        {
            if (ProductTypesList.Count == 0)
            {
                var productTypesList = await _productTypesService.Get<List<ProductTypes>>(null);
                ProductTypesList.Add(new ProductTypes("All"));
                foreach (var item in productTypesList)
                {
                    ProductTypesList.Add(item);
                }
            }

            if (SelectedProductTypes != null)
            {
                ProductsSearchRequest searchRequest = new ProductsSearchRequest();
                if (SelectedProductTypes.Name == "All")
                    searchRequest = null;
                else
                    searchRequest.ProductTypeId = SelectedProductTypes.Id;
                var list = await _service.Get<IEnumerable<Products>>(searchRequest);
                ProductsList.Clear();
                foreach (var item in list)
                {
                    ProductsList.Add(item);
                }
            }
        }
        public async Task SearchedProducts(string serachBar)
        {
            ProductsSearchRequest request = new ProductsSearchRequest
            {
                ProductName = serachBar
            };
            ProductsList.Clear();
            var list = await _service.Get<IEnumerable<Model.Products>>(request);
            foreach (var item in list)
            {
                ProductsList.Add(item);
            }
        }
    }
}
