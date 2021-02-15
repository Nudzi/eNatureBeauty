using eNatureBeauty.Mobile.Models;
using eNatureBeauty.Mobile.ViewModels;
using eNatureBeauty.Mobile.Views;
using eNatureBeauty.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace eNatureBeauty.Mobile
{
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainViewModel model = null;
        public MainPage(Model.Users user)
        {
            InitializeComponent();
            MasterBehavior = MasterBehavior.Popover;
            BindingContext = model = new MainViewModel() { User = user };

            //MenuPages.Add((int)MenuItemType.Browse, (NavigationPage)Detail);
        }
        public async Task NavigateFromMenu(int id, Users user)
        {
            user = model.User;
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.Products:
                        MenuPages.Add(id, new NavigationPage(new ProductsPage(user)));
                        break;
                    case (int)MenuItemType.Welcome:
                        MenuPages.Add(id, new NavigationPage(new ItemsPage()));
                        break;
                    case (int)MenuItemType.AboutUs:
                        MenuPages.Add(id, new NavigationPage(new AboutPage(user)));
                        break;
                    case (int)MenuItemType.Profile:
                        MenuPages.Add(id, new NavigationPage(new EditProfilPage(user)));
                        break;
                    case (int)MenuItemType.Cart:
                        MenuPages.Add(id, new NavigationPage(new OrdersPage(user)));
                        break;
                    case (int)MenuItemType.Orders:
                        MenuPages.Add(id, new NavigationPage(new AllOrdersPage(user)));
                        break;
                        //case (int)MenuItemType.Zahtjevi:
                        //    MenuPages.Add(id, new NavigationPage(new ZahtjeviPage()));
                        //    break;
                        //case (int)MenuItemType.HistorijaZahtjeva:
                        //    MenuPages.Add(id, new NavigationPage(new HistorijaZahtjevaPage()));
                        //    break;
                        //case (int)MenuItemType.HistorijaNarudzbi:
                        //    MenuPages.Add(id, new NavigationPage(new HistorijaNarudzbi()));
                        //    break;
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}
