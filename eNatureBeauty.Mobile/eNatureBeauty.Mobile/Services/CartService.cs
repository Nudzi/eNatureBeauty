﻿using eNatureBeauty.Mobile.ViewModels;
using System.Collections.Generic;

namespace eNatureBeauty.Mobile.Services
{
    public static class CartService
    {
        public static Dictionary<int, ProductsDetailViewModel> Cart { get; set; } = new Dictionary<int, ProductsDetailViewModel>();
    }
}
