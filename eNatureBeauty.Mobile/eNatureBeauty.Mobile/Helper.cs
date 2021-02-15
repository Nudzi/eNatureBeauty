using eNatureBeauty.Mobile.Services;
using eNatureBeauty.Model.Requests.InputProducts;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace eNatureBeauty.Mobile
{
    public class Helper
    {
        private static Random random = new Random();
        public static string Alphabet =
"abcdefghijklmnopqrstuvwyxzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789/=-(*)&^%$#@!";
        private static int generateSize = 19;
        private static APIService _productsService = new APIService("products");
        private static APIService _outputsService = new APIService("outputs");
        private static APIService _outputsProductsService = new APIService("outputProducts");
        private static APIService _inputsProductsService = new APIService("inputProducts");
        private static APIService _inputsService = new APIService("inputs");
        private static APIService _productTypesService = new APIService("productTypes");

        public static async Task<int> numOfBought(int productId)
        {
            int total = 0;

            List<Model.OutputProducts> outputProducts = await _outputsProductsService.Get<List<Model.OutputProducts>>("");
            foreach (var item in outputProducts)
            {
                if (item.ProductId == productId)
                    total += item.Quantity;

            }
            return total;
        }
        public async static Task<int> numInStorage(int productId)
        {
            int total = 0;
            List<Model.InputProducts> inputProducts = await _inputsProductsService.Get<List<Model.InputProducts>>("");
            foreach (var item in inputProducts)
            {
                if (item.ProductId == productId)
                    total += item.Quantity;

            }
            int bought = await numOfBought(productId);
            total -= bought;
            return total;
        }
        public static string GenerateString(int size)
        {
            char[] chars = new char[size];
            for (int i = 0; i < size; i++)
            {
                chars[i] = Alphabet[random.Next(Alphabet.Length)];
            }
            return new string(chars);
        }
        public static async Task CalculateInputProductsPrice(List<InputProductsAdd> _productsAdd)
        {
            foreach (var item in _productsAdd)
            {
                var tmp = await _productsService.GetById<Model.Products>(item.ProductId);
                item.Price = tmp.Price * item.Quantity;
            }
        }

    }
}