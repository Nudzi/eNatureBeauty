using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eNatureBeauty.WebAPI.Database
{
    public partial class natureBeautyContext
    {
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Units>().HasData(Helper.Methods.LoadJsonFromFile<Units>
                  ("Units.json"));
            modelBuilder.Entity<IngredientTypes>().
                HasData(Helper.Methods.LoadJsonFromFile<IngredientTypes>
                ("IngredientTypes.json"));
            modelBuilder.Entity<Ingredients>().HasData(Helper.Methods.LoadJsonFromFile<Ingredients>
                ("Ingredients.json"));
            modelBuilder.Entity<IngredientsIngredientTypes>().HasData(Helper.Methods.LoadJsonFromFile<IngredientsIngredientTypes>
                ("IngredientsIngredientTypes.json"));
            modelBuilder.Entity<InputProducts>().HasData(Helper.Methods.LoadJsonFromFile<InputProducts>
                ("InputProducts.json"));
            modelBuilder.Entity<Inputs>().HasData(Helper.Methods.LoadJsonFromFile<Inputs>
                ("Inputs.json"));
            modelBuilder.Entity<Orders>().HasData(Helper.Methods.LoadJsonFromFile<Orders>
                ("Orders.json"));
            modelBuilder.Entity<OutputProducts>().HasData(Helper.Methods.LoadJsonFromFile<OutputProducts>
                ("OutputProducts.json"));
            modelBuilder.Entity<Outputs>().HasData(Helper.Methods.LoadJsonFromFile<Outputs>
                ("Outputs.json"));
            modelBuilder.Entity<ProductIngredients>().HasData(Helper.Methods.LoadJsonFromFile<ProductIngredients>
                ("ProductIngredients.json"));
            modelBuilder.Entity<ProductTypes>().HasData(Helper.Methods.LoadJsonFromFile<ProductTypes>
                ("ProductTypes.json"));
            modelBuilder.Entity<Products>().HasData(Helper.Methods.LoadJsonFromFile<Products>
                ("Products.json"));
            modelBuilder.Entity<Reviews>().HasData(Helper.Methods.LoadJsonFromFile<Reviews>
                ("Reviews.json"));


            modelBuilder.Entity<Storages>().HasData(Helper.Methods.LoadJsonFromFile<Storages>
               ("Storages.json"));
            modelBuilder.Entity<UserAddresses>().HasData(Helper.Methods.LoadJsonFromFile<UserAddresses>
               ("UserAddresses.json"));
            modelBuilder.Entity<UserTypes>().HasData(Helper.Methods.LoadJsonFromFile<UserTypes>
               ("UserTypes.json"));
            modelBuilder.Entity<Users>().HasData(Helper.Methods.LoadJsonFromFile<Users>
               ("Users.json"));
            modelBuilder.Entity<UsersUserTypes>().HasData(Helper.Methods.LoadJsonFromFile<UsersUserTypes>
               ("UsersUserTypes.json"));


            modelBuilder.Entity<Wishlists>().HasData(Helper.Methods.LoadJsonFromFile<Wishlists>
               ("Wishlists.json"));
        }
    }
}