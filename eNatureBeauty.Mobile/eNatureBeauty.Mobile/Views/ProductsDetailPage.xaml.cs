using eNatureBeauty.Mobile.ViewModels;
using eNatureBeauty.Model;
using eNatureBeauty.Model.Reviews;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eNatureBeauty.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductsDetailPage : ContentPage
    {
        ProductsDetailViewModel model = null;
        public ProductsDetailPage(Products product, Users user)
        {
            InitializeComponent();
            BindingContext = model = new ProductsDetailViewModel() { Product = product, User = user };
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Reviews;
            await model.DeleteReview(item.Id);
        }

        private async void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            var item = e.Value;
            if(!model.isFirstTime)
                await model.EditInWishlist(item);
            model.isFirstTime = false;
        }

        private async void ListView_ItemSelected_1(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Products;
            await Navigation.PushAsync(new ProductsDetailPage(item, model.User));
        }
    }
}