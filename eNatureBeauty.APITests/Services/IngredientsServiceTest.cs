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
    public class IngredientsServiceTest
    {
        private IngredientsService _ingredientsService;
        private natureBeautyContext _context = new natureBeautyContext();
        private IMapper _mapper;

        public IngredientsServiceTest()
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
            _ingredientsService = new IngredientsService(_context, _mapper);
        }
        [Fact]
        public void GetByIngredientNameReturnObject()
        {
            IngredientsSearchRequest request = new IngredientsSearchRequest
            {
                Name = "1"
            };
            _context.Ingredients.Add(new Ingredients
            {
                Id = 1,
                Description = "",
                Name = "1",
                UnitId = 1
            });
            _context.Ingredients.Add(new Ingredients
            {
                Id = 2,
                Description = "",
                Name = "2",
                UnitId = 2
            });
            _context.SaveChanges();
            _ingredientsService = new IngredientsService(_context, _mapper);
            //Act
            var list = _ingredientsService.Get(request);
            //Assert
            Assert.IsType<List<Model.Ingredients>>(list);
            Assert.Single(list);
        }
        [Fact]
        public void GetByIngredientNameReturnEmpty()
        {
            IngredientsSearchRequest request = new IngredientsSearchRequest
            {
                Name = "100"
            };
            _context.Ingredients.Add(new Ingredients
            {
                Id = 3,
                Description = "",
                Name = "3",
                UnitId = 3
            });
            _context.SaveChanges();
            _ingredientsService = new IngredientsService(_context, _mapper);
            //Act
            var list = _ingredientsService.Get(request);
            //Assert
            Assert.IsType<List<Model.Ingredients>>(list);
            Assert.Empty(list);
        }
        [Fact]
        public void DeleteByIdSucessfullyReturnObject()
        {
            _context.Ingredients.Add(new Ingredients
            {
                Id = 4,
                Description = "",
                Name = "4",
                UnitId = 4
            });
            _context.SaveChanges();
            var oldList = _context.Ingredients.Local.Count;
            // Act
            _ingredientsService.Delete(4);
            // Assert
            Assert.Equal(oldList - 1, _context.Ingredients.Local.Count);
        }
        [Fact]
        public void DeleteByIdReturnNullException()
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => _ingredientsService.Delete(100));
        }
        [Fact]
        public void GetByIdSucessfullyReturnObject()
        {
            _context.Ingredients.Add(new Ingredients
            {
                Id = 9,
                Description = "",
                Name = "",
                UnitId = 9
            });
            _context.SaveChanges();
            _ingredientsService = new IngredientsService(_context, _mapper);
            // Act
            var item = _ingredientsService.GetById(9);
            // Assert
            Assert.IsType<Model.Ingredients>(item);
            Assert.NotNull(item);
        }
        [Fact]
        public void GetByIdReturnNullObject()
        {
            // Act
            var item = _ingredientsService.GetById(100);
            // Assert
            Assert.Null(item);
        }
        [Fact]
        public void InsertItemSuccessfullyReturnObject()
        {
            var request = new IngredientsUpsertRequest
            {
                Id = 6,
                Description = "",
                Name = "",
                UnitID = 6
            };
            //Act
            var oldList = _context.Ingredients.Local.Count;
            _ingredientsService.Insert(request);
            //Assert
            Assert.Equal(oldList + 1, _context.Ingredients.Local.Count);
        }
        [Fact]
        public void InsertItemSuccessfullyWithTypesReturnObject()
        {
            var request = new IngredientsUpsertRequest
            {
                Id = 10,
                Description = "",
                Name = "",
                UnitID = 10,
                IngredientsTypes = new List<int>() { 1 }
            };
            //Act
            var oldList = _context.Ingredients.Local.Count;
            var oldListTypes = _context.IngredientsIngredientTypes.Local.Count;
            _ingredientsService.Insert(request);
            //Assert
            Assert.Equal(oldList + 1, _context.Ingredients.Local.Count);
            Assert.Equal(oldListTypes + 1, _context.IngredientsIngredientTypes.Local.Count);
        }
        [Fact]
        public void UpdateItemSuccessfullyReturnObject()
        {
            _context.Ingredients.Add(new Ingredients
            {
                Id = 7,
                Description = "",
                Name = "",
                UnitId = 7
            });
            _context.SaveChanges();
            _ingredientsService = new IngredientsService(_context, _mapper);

            var request = new IngredientsUpsertRequest
            {
                Id = 7,
                Description = "",
                Name = "7",
                UnitID = 7
            };
            //Act
            _ingredientsService.Update(7, request);
            var item = _ingredientsService.GetById(7);
            //Assert
            Assert.Equal(request.Name, item.Name);
        }
    }
}
