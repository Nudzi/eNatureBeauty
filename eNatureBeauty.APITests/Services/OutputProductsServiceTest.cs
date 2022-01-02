using AutoMapper;
using eNatureBeauty.Model.Requests.OutputProducts;
using eNatureBeauty.WebAPI.Database;
using eNatureBeauty.WebAPI.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Xunit;

namespace eNatureBeauty.Test.Services
{
    public class OutputProductsServiceTest
    {
        private OutputProductsService _outputProductsService;
        private natureBeautyContext _context = new natureBeautyContext();
        private IMapper _mapper;
        public OutputProductsServiceTest()
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
            _outputProductsService = new OutputProductsService(_context, _mapper);
        }

        [Fact]
        public void FilterByOutputId_ReturnObject()
        {
            _context.OutputProducts.Add(new OutputProducts
            {
                Id = 1,
                OutputId = 1,
                Discount = 0,
                Price = 0,
                ProductId = 1,
                Quantity = 0
            });
            _context.OutputProducts.Add(new OutputProducts
            {
                Id = 2,
                OutputId = 2,
                Discount = 0,
                Price = 0,
                ProductId = 2,
                Quantity = 0
            });
            _context.SaveChanges();
            _outputProductsService = new OutputProductsService(_context, _mapper);
            OutputProductsSearchRequest request = new OutputProductsSearchRequest
            {
                OutputId = 1
            };
            // Act
            var list = _outputProductsService.Get(request);
            // Assert
            Assert.IsType<List<Model.OutputProducts>>(list);
            Assert.Single(list);
        }
        [Fact]
        public void FilterByProductId_ReturnObject()
        {
            _context.OutputProducts.Add(new OutputProducts
            {
                Id = 3,
                OutputId = 3,
                Discount = 0,
                Price = 0,
                ProductId = 3,
                Quantity = 0
            });
            _context.OutputProducts.Add(new OutputProducts
            {
                Id = 4,
                OutputId = 4,
                Discount = 0,
                Price = 0,
                ProductId = 4,
                Quantity = 0
            });
            _context.SaveChanges();
            _outputProductsService = new OutputProductsService(_context, _mapper);
            OutputProductsSearchRequest request = new OutputProductsSearchRequest
            {
                ProductId = 4
            };
            // Act
            var list = _outputProductsService.Get(request);
            // Assert
            Assert.IsType<List<Model.OutputProducts>>(list);
            Assert.Single(list);
        }
        [Fact]
        public void FilterEmpty_ReturnWholeList()
        {
            _context.OutputProducts.Add(new OutputProducts
            {
                Id = 5,
                OutputId = 5,
                Discount = 0,
                Price = 0,
                ProductId = 5,
                Quantity = 0
            });
            _context.SaveChanges();
            _outputProductsService = new OutputProductsService(_context, _mapper);
            OutputProductsSearchRequest request = new OutputProductsSearchRequest();
            // Act
            var list = _outputProductsService.Get(request);
            // Assert
            Assert.IsType<List<Model.OutputProducts>>(list);
            Assert.Equal(list.Count, _context.OutputProducts.Local.Count);
        }
        [Fact]
        public void FilterByOutputIdAndProductId_ReturnEmpty()
        {
            _context.OutputProducts.Add(new OutputProducts
            {
                Id = 6,
                OutputId = 6,
                Discount = 0,
                Price = 0,
                ProductId = 6,
                Quantity = 0
            });
            _context.SaveChanges();
            _outputProductsService = new OutputProductsService(_context, _mapper);
            OutputProductsSearchRequest request = new OutputProductsSearchRequest
            {
                ProductId = 7,
                OutputId = 7
            };
            // Act
            var list = _outputProductsService.Get(request);
            // Assert
            Assert.IsType<List<Model.OutputProducts>>(list);
            Assert.Empty(list);
        }
        [Fact]
        public void FilterByOutputIdAndProductId_ReturnObject()
        {
            _context.OutputProducts.Add(new OutputProducts
            {
                Id = 8,
                OutputId = 8,
                Discount = 0,
                Price = 0,
                ProductId = 8,
                Quantity = 0
            });
            _context.SaveChanges();
            _outputProductsService = new OutputProductsService(_context, _mapper);
            OutputProductsSearchRequest request = new OutputProductsSearchRequest
            {
                ProductId = 8,
                OutputId = 8
            };
            // Act
            var list = _outputProductsService.Get(request);
            // Assert
            Assert.IsType<List<Model.OutputProducts>>(list);
            Assert.Single(list);
        }
    }
}
