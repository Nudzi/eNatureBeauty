using eNatureBeauty.Mobile.Services;
using eNatureBeauty.Mobile.ViewModels;
using eNatureBeauty.Model;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eNatureBeauty.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrdersDetailPage : ContentPage
    {
        OrdersDetailPageViewModel model = null;
        public OrdersDetailPage(Users user)
        {
            InitializeComponent();
            BindingContext = model = new OrdersDetailPageViewModel { User = user };
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.RemovePage(this);
            CartService.Cart.Clear();
            await Navigation.PushAsync(new ProductsPage(model.User));

        }

        //private async void Entry_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    await model.Init();
        //    await model.StateLenght();
        //}

        //private async void Entry_TextChanged_1(object sender, TextChangedEventArgs e)
        //{
        //    await model.Init();

        //    await model.CityLenght();

        //}

        //private async void Entry_TextChanged_2(object sender, TextChangedEventArgs e)
        //{
        //    await model.Init();

        //    await model.AddressLenght();
        //}
    }
}