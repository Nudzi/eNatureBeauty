using eNatureBeauty.Mobile.ViewModels;
using eNatureBeauty.Model;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eNatureBeauty.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductsPage : ContentPage
    {
        public ProductsViewModel model = null;
        public ProductsPage(Users user)
        {
            InitializeComponent();
            BindingContext = model = new ProductsViewModel { User = user};
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Products;

            await Navigation.PushAsync(new ProductsDetailPage(item, model.User));
        }

        private async void SearchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            await model.SearchedProducts(searchBar.Text);
        }
    }
}