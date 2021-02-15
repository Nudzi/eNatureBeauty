using AutoMapper;
using eNatureBeauty.Model;
using eNatureBeauty.Model.Requests;
using eNatureBeauty.Model.Requests.InputProducts;
using eNatureBeauty.Model.Requests.Inputs;
using eNatureBeauty.Model.Requests.Orders;
using eNatureBeauty.Model.Requests.OutputProducts;
using eNatureBeauty.Model.Requests.Outputs;
using eNatureBeauty.Model.Requests.ProductsIngredients;
using eNatureBeauty.Model.Requests.UserAddresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reviews = eNatureBeauty.Model.Reviews.Reviews;

namespace eNatureBeauty.WebAPI.Mappers
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            //users
            CreateMap<Database.UserTypes, Model.UserTypes>();
            CreateMap<Database.Users, Model.Users>();
            CreateMap<Database.Users, UsersInsertRequest>().ReverseMap();
            //userTypes
            CreateMap<Database.UserTypes, Model.UserTypes>();

            //ingredients
            CreateMap<Database.Ingredients, Model.Ingredients>();
            CreateMap<Database.IngredientTypes, Model.IngredientTypes>();
            CreateMap<Database.Ingredients, IngredientsUpsertRequest>().ReverseMap();
            CreateMap<Database.IngredientsIngredientTypes, Model.IngredientsIngredientTypes>().ReverseMap();
            
            //products
            CreateMap<Database.Products, Model.Products>();
            CreateMap<Database.Products, ProductsUpsertRequest>().ReverseMap();
            CreateMap<Database.ProductTypes, Model.ProductTypes>();
            CreateMap<Database.ProductIngredients, Model.ProductsIngredients>();

            //inputs
            CreateMap<Database.Inputs, Model.Inputs>();
            CreateMap<Database.Inputs, InputsUpsertRequest>().ReverseMap();
            CreateMap<Database.InputProducts, Model.InputProducts>();
            CreateMap<Database.InputProducts, InputProductsUpsertRequest>().ReverseMap();
            //orders
            CreateMap<Database.Orders, Model.Orders>();
            CreateMap<Database.Orders, OrdersUpsertRequest>().ReverseMap();
            //outputs
            CreateMap<Database.Outputs, Model.Outputs>();
            CreateMap<Database.OutputProducts, Model.OutputProducts>();
            CreateMap<Database.Outputs, OutputsUpsertRequest>().ReverseMap();
            CreateMap<Database.OutputProducts, OutputProductsUpsertRequest>().ReverseMap();

            //units
            CreateMap<Database.Units, Model.Units>();

            //productIngredients
            CreateMap<Database.ProductIngredients, Model.ProductsIngredients>();
            CreateMap<Database.ProductIngredients, ProductsIngredientsUpsertRequest>().ReverseMap();

            //useraddresses
            CreateMap<Database.UserAddresses, Model.UserAddresses>();
            CreateMap<Database.UserAddresses, UserAddressesUpsertRequest>().ReverseMap();
            //storages
            CreateMap<Database.Storages, StoragesUpsertRequest>().ReverseMap();
            CreateMap<Database.Storages, Model.Storages>();
            //wishlists
            CreateMap<Database.Wishlists, Model.Wishlists>();
            CreateMap<Database.Wishlists, WishlistsUpsertRequest>().ReverseMap();
            //reviews
            CreateMap<Database.Reviews, Reviews>();
            CreateMap<Database.Reviews, ReviewsUpsertRequest>().ReverseMap();
            //storages
            CreateMap<Database.Storages, Storages>();

        }
    }
}
