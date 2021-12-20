using AutoMapper;
using eNatureBeauty.Model.Requests.Inputs;
using eNatureBeauty.WebAPI.Database;
using eNatureBeauty.WebAPI.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Xunit;

namespace eNatureBeauty.Test.Services
{
    public class InputProductsServiceTest
    {
        private InputProductsService _inputProductsService;
        private natureBeautyContext _context = new natureBeautyContext();
        private IMapper _mapper;
        public InputProductsServiceTest()
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
            _inputProductsService = new InputProductsService(_context, _mapper);
        }

        [Fact]
        public void FilterByProductIdReturnObject()
        {
            _context.InputProducts.Add(new InputProducts
            {
                Id = 1,
                InputId = 1,
                ProductId = 1,
                Quantity = 0
            });
            _context.InputProducts.Add(new InputProducts
            {
                Id = 2,
                InputId = 2,
                ProductId = 2,
                Quantity = 0
            });
            _context.SaveChanges();
            _inputProductsService = new InputProductsService(_context, _mapper);
            InputProductsSearchRequest request = new InputProductsSearchRequest
            {
                ProductId = 1
            };
            // Act
            var list = _inputProductsService.Get(request);
            // Assert
            Assert.IsType<List<Model.InputProducts>>(list);
            Assert.Single(list);
        }
        [Fact]
        public void FilterByInputIdReturnObject()
        {
            _context.InputProducts.Add(new InputProducts
            {
                Id = 3,
                InputId = 3,
                ProductId = 3,
                Quantity = 0
            });
            _context.InputProducts.Add(new InputProducts
            {
                Id = 4,
                InputId = 4,
                ProductId = 4,
                Quantity = 0
            });
            _context.SaveChanges();
            _inputProductsService = new InputProductsService(_context, _mapper);
            InputProductsSearchRequest request = new InputProductsSearchRequest
            {
                InputId = 4
            };
            // Act
            var list = _inputProductsService.Get(request);
            // Assert
            Assert.IsType<List<Model.InputProducts>>(list);
            Assert.Single(list);
        }
        [Fact]
        public void FilterEmptyReturnWholeList()
        {
            _context.InputProducts.Add(new InputProducts
            {
                Id = 5,
                InputId = 5,
                ProductId = 5,
                Quantity = 0
            });
            _context.SaveChanges();
            _inputProductsService = new InputProductsService(_context, _mapper);
            InputProductsSearchRequest request = new InputProductsSearchRequest();
            // Act
            var list = _inputProductsService.Get(request);
            // Assert
            Assert.IsType<List<Model.InputProducts>>(list);
            Assert.Equal(list.Count, _context.InputProducts.Local.Count);
        }
        [Fact]
        public void FilterByProductIdAndInputIdReturnEmpty()
        {
            _context.InputProducts.Add(new InputProducts
            {
                Id = 6,
                InputId = 6,
                ProductId = 6,
                Quantity = 0
            });
            _context.SaveChanges();
            _inputProductsService = new InputProductsService(_context, _mapper);
            InputProductsSearchRequest request = new InputProductsSearchRequest
            {
                InputId = 7,
                ProductId = 7
            };
            // Act
            var list = _inputProductsService.Get(request);
            // Assert
            Assert.IsType<List<Model.InputProducts>>(list);
            Assert.Empty(list);
        }
        [Fact]
        public void FilterByInputIdAndProductIdReturnObject()
        {
            _context.InputProducts.Add(new InputProducts
            {
                Id = 8,
                InputId = 8,
                ProductId = 8,
                Quantity = 0
            });
            _context.SaveChanges();
            _inputProductsService = new InputProductsService(_context, _mapper);
            InputProductsSearchRequest request = new InputProductsSearchRequest
            {
                InputId = 8,
                ProductId = 8
            };
            // Act
            var list = _inputProductsService.Get(request);
            // Assert
            Assert.IsType<List<Model.InputProducts>>(list);
            Assert.Single(list);
        }
    }
}
