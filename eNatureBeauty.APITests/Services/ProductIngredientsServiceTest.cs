using AutoMapper;
using eNatureBeauty.Model.Requests.ProductsIngredients;
using eNatureBeauty.WebAPI.Database;
using eNatureBeauty.WebAPI.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Xunit;

namespace eNatureBeauty.Test.Services
{
    public class ProductIngredientsServiceTest
    {
        private ProductsIngredientsService _productIngredientsService;
        private natureBeautyContext _context = new natureBeautyContext();
        private IMapper _mapper;
        public ProductIngredientsServiceTest()
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
            _productIngredientsService = new ProductsIngredientsService(_context, _mapper);
        }

        [Fact]
        public void FilterByProductIdReturnObject()
        {
            _context.ProductIngredients.Add(new ProductIngredients
            {
                Id = 1,
                IngredientId = 1,
                Measure = 0,
                ProductId = 1
            });
            _context.ProductIngredients.Add(new ProductIngredients
            {
                Id = 2,
                IngredientId = 2,
                Measure = 0,
                ProductId = 2
            });
            _context.SaveChanges();
            _productIngredientsService = new ProductsIngredientsService(_context, _mapper);
            ProductsIngredientsSearchRequest request = new ProductsIngredientsSearchRequest
            {
                ProductID = 1
            };
            // Act
            var list = _productIngredientsService.Get(request);
            // Assert
            Assert.IsType<List<Model.ProductsIngredients>>(list);
            Assert.Single(list);
        }
        [Fact]
        public void FilterByProductIdReturnEmpty()
        {
            _context.ProductIngredients.Add(new ProductIngredients
            {
                Id = 3,
                IngredientId = 3,
                Measure = 0,
                ProductId = 3
            });
            _context.ProductIngredients.Add(new ProductIngredients
            {
                Id = 4,
                IngredientId = 4,
                Measure = 0,
                ProductId = 4
            });
            _context.SaveChanges();
            _productIngredientsService = new ProductsIngredientsService(_context, _mapper);
            ProductsIngredientsSearchRequest request = new ProductsIngredientsSearchRequest
            {
                ProductID = 100
            };
            // Act
            var list = _productIngredientsService.Get(request);
            // Assert
            Assert.IsType<List<Model.ProductsIngredients>>(list);
            Assert.Empty(list);
        }
        [Fact]
        public void FilterEmptyReturnWholeList()
        {
            _context.ProductIngredients.Add(new ProductIngredients
            {
                Id = 5,
                IngredientId = 5,
                Measure = 0,
                ProductId = 5
            });
            _context.ProductIngredients.Add(new ProductIngredients
            {
                Id = 6,
                IngredientId = 6,
                Measure = 0,
                ProductId = 6
            });
            _context.SaveChanges();
            _productIngredientsService = new ProductsIngredientsService(_context, _mapper);
            ProductsIngredientsSearchRequest request = new ProductsIngredientsSearchRequest();
            // Act
            var list = _productIngredientsService.Get(request);
            // Assert
            Assert.IsType<List<Model.ProductsIngredients>>(list);
            Assert.Equal(list.Count, _context.ProductIngredients.Local.Count);
        }
    }
}