using eNatureBeauty.Mobile.ViewModels;
using eNatureBeauty.Model;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eNatureBeauty.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrdersPage : ContentPage
    {
        OrdersViewModel model = null;
        ProductsDetailViewModel test = null;
        public OrdersPage(Users user)
        {
            InitializeComponent();
            BindingContext = model = new OrdersViewModel { User = user };

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            model.Init();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new OrdersPage(model.User));
            Navigation.RemovePage(this);
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new OrdersDetailPage(model.User));
        }
    }
}