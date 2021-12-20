using AutoMapper;
using eNatureBeauty.Model.Requests;
using eNatureBeauty.WebAPI.Database;
using eNatureBeauty.WebAPI.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Xunit;

namespace eNatureBeauty.Test.Services
{
    public class RecommenderServiceTest
    {
        private RecommenderService _recommenderService;
        private natureBeautyContext _context = new natureBeautyContext();
        private IMapper _mapper;

        public RecommenderServiceTest()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new WebAPI.Mappers.Mapper());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
            // Insert seed data into the database using one instance of the context
            var options = new DbContextOptionsBuilder<natureBeautyContext>()
            .UseInMemoryDatabase(databaseName: "eNatureBeauty").Options;

            _context = new natureBeautyContext(options);
            _recommenderService = new RecommenderService(_context, _mapper);
        }
        [Fact]
        public void GetAlikeProductsWithReturnObject()
        {
            var outputProduct = new OutputProducts
            {
                Id = 18,
                Discount = 0,
                OutputId = 18,
                Price = 0,
                ProductId = 18,
                Quantity = 0
            };
            var productType1 = new ProductTypes
            {
                Id = 18,
                Name = ""
            };
            _context.Products.Add(new Products
            {
                Id = 18,
                Name = "",
                Code = "",
                Description = "",
                Image = null,
                ImageThumb = null,
                Price = 0,
                ProductTypeId = 18,
                ProductType = productType1,
                OutputProducts = new List<OutputProducts>()
                {
                    outputProduct
                }
            });
            _context.Products.Add(new Products
            {
                Id = 19,
                Name = "",
                Code = "",
                Description = "",
                Image = null,
                ImageThumb = null,
                Price = 0,
                ProductTypeId = 18,
                ProductType = productType1,
                OutputProducts = new List<OutputProducts>()
                {
                    outputProduct
                }
            });
            _context.Reviews.Add(new Reviews
            {
                Id = 18,
                ProductId = 18,
                Description = "",
                UserId = 1,
                Review = 10
            }); 
            _context.Reviews.Add(new Reviews
            {
                Id = 19,
                ProductId = 19,
                Description = "",
                UserId = 1,
                Review = 10
            });
            _context.Reviews.Add(new Reviews
            {
                Id = 20,
                ProductId = 18,
                Description = "",
                UserId = 1,
                Review = 10
            });
            _context.SaveChanges();
            _recommenderService = new RecommenderService(_context, _mapper);

            var list = _recommenderService.GetAlikeProducts(18);
            Assert.Single(list);
            Assert.IsType<List<Model.Products>>(list);
        }
        [Fact]
        public void GetAlikeProductsWithReturnNullBecauseOfTheLowReviews()
        {
            var outputProduct = new OutputProducts
            {
                Id = 20,
                Discount = 0,
                OutputId = 20,
                Price = 0,
                ProductId = 20,
                Quantity = 0
            };
            var productType2 = new ProductTypes
            {
                Id = 20,
                Name = ""
            };
            _context.Products.Add(new Products
            {
                Id = 20,
                Name = "",
                Code = "",
                Description = "",
                Image = null,
                ImageThumb = null,
                Price = 0,
                ProductTypeId = 20,
                ProductType = productType2,
                OutputProducts = new List<OutputProducts>()
                {
                    outputProduct
                }
            });
            _context.Products.Add(new Products
            {
                Id = 21,
                Name = "",
                Code = "",
                Description = "",
                Image = null,
                ImageThumb = null,
                Price = 0,
                ProductTypeId = 20,
                ProductType = productType2,
                OutputProducts = new List<OutputProducts>()
                {
                    outputProduct
                }
            });
            _context.Reviews.Add(new Reviews
            {
                Id = 21,
                ProductId = 21,
                Description = "",
                UserId = 21,
                Review = 1
            });
            _context.SaveChanges();
            _recommenderService = new RecommenderService(_context, _mapper);

            var list = _recommenderService.GetAlikeProducts(21);
            Assert.Empty(list);
        }
    }
}
