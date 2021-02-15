using eNatureBeauty.Mobile.Models;
using eNatureBeauty.Model;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace eNatureBeauty.Mobile.Views
{
    [DesignTimeVisible(false)]
    public partial class MenuPage : ContentPage
    {
        public ListView ListView;
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<HomeMenuItem> menuItems;
        Users user;
        public MenuPage()
        {
            InitializeComponent();
            ListView = MenuItemsListView;

            menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem {Id = MenuItemType.Welcome, Title="Welcome" },
                new HomeMenuItem {Id = MenuItemType.Products, Title="Products" },
                new HomeMenuItem {Id = MenuItemType.Profile, Title="Profile" },
                new HomeMenuItem {Id = MenuItemType.Cart, Title="Cart" },
                new HomeMenuItem {Id = MenuItemType.Orders, Title="Orders" },
                new HomeMenuItem {Id = MenuItemType.AboutUs, Title="About Us" },
            };

            MenuItemsListView.ItemsSource = menuItems;

            MenuItemsListView.SelectedItem = menuItems[0];
            MenuItemsListView.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((HomeMenuItem)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id, user);
            };
        }
    }
}
