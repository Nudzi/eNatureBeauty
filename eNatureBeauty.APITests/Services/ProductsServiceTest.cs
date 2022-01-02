using AutoMapper;
using eNatureBeauty.Model.Requests;
using eNatureBeauty.WebAPI.Database;
using eNatureBeauty.WebAPI.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Xunit;

namespace eNatureBeauty.Test.Services
{
    public class ProductsServiceTest
    {
        private ProductsService _productsService;
        private natureBeautyContext _context = new natureBeautyContext();
        private IMapper _mapper;
        public ProductsServiceTest()
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
            
            var options = new DbContextOptionsBuilder<natureBeautyContext>()
            .UseInMemoryDatabase(databaseName: "eNatureBeauty").Options;

            _context = new natureBeautyContext(options);
            _productsService = new ProductsService(_context, _mapper);
        }

        [Fact]
        public void FilterByProductTypeId()
        {
            _context.Products.Add(new Products
            {
                Id = 1,
                Name = "",
                Code = "",
                Description = "",
                Image = null,
                ImageThumb = null,
                Price = 0,
                ProductTypeId = 1
            });
            _context.Products.Add(new Products
            {
                Id = 2,
                Name = "",
                Code = "",
                Description = "",
                Image = null,
                ImageThumb = null,
                Price = 0,
                ProductTypeId = 2
            });
            _context.SaveChanges();
            _productsService = new ProductsService(_context, _mapper);
            ProductsSearchRequest request = new ProductsSearchRequest
            {
                ProductTypeId = 1
            };
            // Act
            var list = _productsService.Get(request);
            // Assert
            Assert.IsType<List<Model.Products>>(list);
            Assert.Single(list);
        }
        [Fact]
        public void FilterByProductName()
        {
            _context.Products.Add(new Products
            {
                Id = 3,
                Name = "Test3",
                Code = "",
                Description = "",
                Image = null,
                ImageThumb = null,
                Price = 0,
                ProductTypeId = 3
            });
            _context.Products.Add(new Products
            {
                Id = 4,
                Name = "Test4",
                Code = "",
                Description = "",
                Image = null,
                ImageThumb = null,
                Price = 0,
                ProductTypeId = 4
            });
            _context.SaveChanges();
            _productsService = new ProductsService(_context, _mapper);
            ProductsSearchRequest request = new ProductsSearchRequest
            {
                ProductName = "Test3"
            };
            // Act
            var list = _productsService.Get(request);
            // Assert
            Assert.IsType<List<Model.Products>>(list);
            Assert.Single(list);
        }
        [Fact]
        public void FilterByProductNameAndProductId()
        {
            _context.Products.Add(new Products
            {
                Id = 5,
                Name = "Test5",
                Code = "",
                Description = "",
                Image = null,
                ImageThumb = null,
                Price = 0,
                ProductTypeId = 5
            });
            _context.Products.Add(new Products
            {
                Id = 6,
                Name = "Test6",
                Code = "",
                Description = "",
                Image = null,
                ImageThumb = null,
                Price = 0,
                ProductTypeId = 6
            });
            _context.SaveChanges();
            _productsService = new ProductsService(_context, _mapper);
            ProductsSearchRequest request = new ProductsSearchRequest
            {
                ProductName = "Test5",
                ProductTypeId = 5
            };
            // Act
            var list = _productsService.Get(request);
            // Assert
            Assert.IsType<List<Model.Products>>(list);
            Assert.Single(list);
        }
        [Fact]
        public void FilterEmpty_ReturnWholeList()
        {
            _context.Products.Add(new Products
            {
                Id = 7,
                Name = "Test7",
                Code = "",
                Description = "",
                Image = null,
                ImageThumb = null,
                Price = 0,
                ProductTypeId = 7
            });
            _context.SaveChanges();
            _productsService = new ProductsService(_context, _mapper);
            ProductsSearchRequest request = new ProductsSearchRequest();
            // Act
            var list = _productsService.Get(request);
            // Assert
            Assert.IsType<List<Model.Products>>(list);
            Assert.Equal(list.Count, _context.Products.Local.Count);
        }
    }
}
