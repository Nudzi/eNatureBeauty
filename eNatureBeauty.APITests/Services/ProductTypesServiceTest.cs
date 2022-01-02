using AutoMapper;
using eNatureBeauty.WebAPI.Database;
using eNatureBeauty.WebAPI.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Xunit;

namespace eNatureBeauty.Test.Services
{
    public class ProductTypesServiceTest
    {
        private ProductTypesService _productTypesService;
        private natureBeautyContext _context = new natureBeautyContext();
        private IMapper _mapper;
        public ProductTypesServiceTest()
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
            _productTypesService = new ProductTypesService(_context, _mapper);
        }

        [Fact]
        public void GetAllProductTypes_ReturnObject()
        {
            _context.ProductTypes.Add(new ProductTypes
            {
                Id = 1,
                Name = ""
            });
            _context.ProductTypes.Add(new ProductTypes
            {
                Id = 2,
                Name = ""
            });
            _context.SaveChanges();
            _productTypesService = new ProductTypesService(_context, _mapper);
            // Act
            var list = _productTypesService.Get();
            // Assert
            Assert.IsType<List<Model.ProductTypes>>(list);
            Assert.Equal(list.Count, _context.ProductTypes.Local.Count);
        }
        [Fact]
        public void GetByIdSuccessfully_ReturnObject()
        {
            _context.ProductTypes.Add(new ProductTypes
            {
                Id = 3,
                Name = ""
            });
            _context.SaveChanges();
            _productTypesService = new ProductTypesService(_context, _mapper);
            // Act
            var item = _productTypesService.GetById(3);
            // Assert
            Assert.IsType<Model.ProductTypes>(item);
            Assert.NotNull(item);
        }
        [Fact]
        public void GetById_ReturnNullObject()
        {
            // Act
            var item = _productTypesService.GetById(100);
            // Assert
            Assert.Null(item);
        }
    }
}
