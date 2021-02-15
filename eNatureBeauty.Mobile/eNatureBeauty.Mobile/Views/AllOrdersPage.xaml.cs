using eNatureBeauty.Mobile.ViewModels;
using eNatureBeauty.Model;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eNatureBeauty.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AllOrdersPage : ContentPage
    {
        AllOrdersViewModel model = null;
        public AllOrdersPage(Users user)
        {
            InitializeComponent();
            BindingContext = model = new AllOrdersViewModel { User = user };
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Outputs;
            await model.CancelOrder(item.Id);
            await Navigation.PushAsync(new ProductsPage(model.User));
        }
    }
}