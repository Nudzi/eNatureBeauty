using AutoMapper;
using eNatureBeauty.Model.Requests.Inputs;
using eNatureBeauty.WebAPI.Database;
using eNatureBeauty.WebAPI.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Xunit;

namespace eNatureBeauty.Test.Services
{
    public class IngredientTypesServiceTest
    {
        private IngredientTypesService _productTypesService;
        private natureBeautyContext _context = new natureBeautyContext();
        private IMapper _mapper;
        public IngredientTypesServiceTest()
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
            _productTypesService = new IngredientTypesService(_context, _mapper);
        }

        [Fact]
        public void GetAllIngredientTypesReturnAllObjects()
        {
            _context.IngredientTypes.Add(new IngredientTypes
            {
                Id = 1,
                Name = "",
                Description = ""
            });
            _context.IngredientTypes.Add(new IngredientTypes
            {
                Id = 2,
                Name = "",
                Description = ""
            });
            _context.SaveChanges();
            _productTypesService = new IngredientTypesService(_context, _mapper);
            // Act
            var list = _productTypesService.Get();
            // Assert
            Assert.IsType<List<Model.IngredientTypes>>(list);
            Assert.Equal(list.Count, _context.IngredientTypes.Local.Count);
        }
        [Fact]
        public void GetByIdSuccessfullyReturnObject()
        {
            _context.IngredientTypes.Add(new IngredientTypes
            {
                Id = 3,
                Name = "",
                Description = ""
            });
            _context.SaveChanges();
            _productTypesService = new IngredientTypesService(_context, _mapper);
            // Act
            var item = _productTypesService.GetById(3);
            // Assert
            Assert.IsType<Model.IngredientTypes>(item);
            Assert.NotNull(item);
        }
        [Fact]
        public void GetByIdReturnNull()
        {
            // Act
            var item = _productTypesService.GetById(100);
            // Assert
            Assert.Null(item);
        }
    }
}
