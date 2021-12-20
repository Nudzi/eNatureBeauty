using AutoMapper;
using eNatureBeauty.Model.Requests;
using eNatureBeauty.Model.Requests.Inputs;
using eNatureBeauty.WebAPI.Database;
using eNatureBeauty.WebAPI.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Xunit;

namespace eNatureBeauty.Test.Services
{
    public class IngredientsIngredientTypesServiceTest
    {
        private IngredientsIngredientTypesService _ingredientsIngredientTypesService;
        private natureBeautyContext _context = new natureBeautyContext();
        private IMapper _mapper;
        public IngredientsIngredientTypesServiceTest()
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
            _ingredientsIngredientTypesService = new IngredientsIngredientTypesService(_context, _mapper);
        }

        [Fact]
        public void GetByIngredientIdReturnObject()
        {
            IngredientsSearchRequest request = new IngredientsSearchRequest
            {
                IngredientTypeID = 15
            };
            _context.IngredientsIngredientTypes.Add(new IngredientsIngredientTypes
            {
                Id = 15,
                Description = "",
                IngredientId = 15, 
                IngredientTypeId = 15
            });
            _context.IngredientsIngredientTypes.Add(new IngredientsIngredientTypes
            {
                Id = 25,
                Description = "",
                IngredientId = 25,
                IngredientTypeId = 25
            });
            _context.SaveChanges();
            _ingredientsIngredientTypesService = new IngredientsIngredientTypesService(_context, _mapper);
            //Act
            var list = _ingredientsIngredientTypesService.Get(request);
            //Assert
            Assert.IsType<List<Model.IngredientsIngredientTypes>>(list);
            Assert.Single(list);
        }
        [Fact]
        public void GetByIngredientIdReturnEmpty()
        {
            IngredientsSearchRequest request = new IngredientsSearchRequest
            {
                IngredientID = 100
            };
            _context.IngredientsIngredientTypes.Add(new IngredientsIngredientTypes
            {
                Id = 3,
                Description = "",
                IngredientId = 3,
                IngredientTypeId = 3
            });
            _context.SaveChanges();
            _ingredientsIngredientTypesService = new IngredientsIngredientTypesService(_context, _mapper);
            //Act
            var list = _ingredientsIngredientTypesService.Get(request);
            //Assert
            Assert.IsType<List<Model.IngredientsIngredientTypes>>(list);
            Assert.Empty(list);
        }
        [Fact]
        public void GetByIngredientTypeIdReturnEmpty()
        {
            IngredientsSearchRequest request = new IngredientsSearchRequest
            {
                IngredientTypeID = 100
            };
            _context.IngredientsIngredientTypes.Add(new IngredientsIngredientTypes
            {
                Id = 4,
                Description = "",
                IngredientId = 4,
                IngredientTypeId = 4
            });
            _context.SaveChanges();
            _ingredientsIngredientTypesService = new IngredientsIngredientTypesService(_context, _mapper);
            //Act
            var list = _ingredientsIngredientTypesService.Get(request);
            //Assert
            Assert.IsType<List<Model.IngredientsIngredientTypes>>(list);
            Assert.Empty(list);
        }
        [Fact]
        public void GetByIngredientTypeIdReturnObject()
        {
            IngredientsSearchRequest request = new IngredientsSearchRequest
            {
                IngredientTypeID = 5
            };
            _context.IngredientsIngredientTypes.Add(new IngredientsIngredientTypes
            {
                Id = 5,
                Description = "",
                IngredientId = 5,
                IngredientTypeId = 5
            });
            _context.SaveChanges();
            _ingredientsIngredientTypesService = new IngredientsIngredientTypesService(_context, _mapper);
            //Act
            var list = _ingredientsIngredientTypesService.Get(request);
            //Assert
            Assert.IsType<List<Model.IngredientsIngredientTypes>>(list);
            Assert.Single(list);
        }
        [Fact]
        public void GetByIngredientTypeIdAndIngredientIdReturnEmpty()
        {
            IngredientsSearchRequest request = new IngredientsSearchRequest
            {
                IngredientTypeID = 100,
                IngredientID = 100
            };
            _context.IngredientsIngredientTypes.Add(new IngredientsIngredientTypes
            {
                Id = 66,
                Description = "",
                IngredientId = 66,
                IngredientTypeId = 66
            });
            _context.SaveChanges();
            _ingredientsIngredientTypesService = new IngredientsIngredientTypesService(_context, _mapper);
            //Act
            var list = _ingredientsIngredientTypesService.Get(request);
            //Assert
            Assert.IsType<List<Model.IngredientsIngredientTypes>>(list);
            Assert.Empty(list);
        }
        [Fact]
        public void GetByIngredientTypeIdAndIngredientIdReturnObject()
        {
            IngredientsSearchRequest request = new IngredientsSearchRequest
            {
                IngredientTypeID = 7,
                IngredientID = 7
            };
            _context.IngredientsIngredientTypes.Add(new IngredientsIngredientTypes
            {
                Id = 7,
                Description = "",
                IngredientId = 7,
                IngredientTypeId = 7
            });
            _context.SaveChanges();
            _ingredientsIngredientTypesService = new IngredientsIngredientTypesService(_context, _mapper);
            //Act
            var list = _ingredientsIngredientTypesService.Get(request);
            //Assert
            Assert.IsType<List<Model.IngredientsIngredientTypes>>(list);
            Assert.Single(list);
        }
        [Fact]
        public void GetByIdSuccessfullyReturnObject()
        {
            _context.IngredientsIngredientTypes.Add(new IngredientsIngredientTypes
            {
                Id = 8,
                Description = "",
                IngredientId = 8, 
                IngredientTypeId = 8
            });
            _context.SaveChanges();
            _ingredientsIngredientTypesService = new IngredientsIngredientTypesService(_context, _mapper);
            // Act
            var item = _ingredientsIngredientTypesService.GetById(8);
            // Assert
            Assert.IsType<Model.IngredientsIngredientTypes>(item);
            Assert.NotNull(item);
        }
        [Fact]
        public void GetByIdNReturnNullObject()
        {
            // Act
            var item = _ingredientsIngredientTypesService.GetById(100);
            // Assert
            Assert.Null(item);
        }
    }
}
