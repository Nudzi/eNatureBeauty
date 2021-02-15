﻿using eNatureBeauty.Mobile.ViewModels;
using eNatureBeauty.Model;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eNatureBeauty.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilDetailPage : ContentPage
    {
        ProfilViewModel model = null;
        public ProfilDetailPage(Users user)
        {
            InitializeComponent();
            BindingContext = model = new ProfilViewModel { User = Global.LoggedUser }; 
        }
        protected  async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditProfilPage(model.User));
        }
    }
}