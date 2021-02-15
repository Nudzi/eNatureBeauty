using eNatureBeauty.Mobile.Services;
using eNatureBeauty.Model;
using System.Collections.ObjectModel;

namespace eNatureBeauty.Mobile.ViewModels
{
    class OrdersViewModel : BaseViewModel
    {
        public ObservableCollection<ProductsDetailViewModel> ProductsList { get; set; } = new ObservableCollection<ProductsDetailViewModel>();

        public Users User;
        public void Init()
        {
            ProductsList.Clear();
            foreach (var item in CartService.Cart)
            {
                ProductsList.Add(item.Value);
            }
        }
    }
}
