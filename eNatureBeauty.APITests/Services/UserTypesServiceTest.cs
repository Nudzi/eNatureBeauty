using AutoMapper;
using eNatureBeauty.Model.Requests;
using eNatureBeauty.WebAPI.Database;
using eNatureBeauty.WebAPI.Filters;
using eNatureBeauty.WebAPI.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Xunit;

namespace eNatureBeauty.Test.Services
{
    public class UserTypesServiceTest
    {
        private UserTypesService _userTypesService;
        private natureBeautyContext _context = new natureBeautyContext();
        private IMapper _mapper;
        public UserTypesServiceTest()
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
            _userTypesService = new UserTypesService(_context, _mapper);
        }

        [Fact]
        public void FilterByProductIdReturnObject()
        {
            _context.UserTypes.Add(new UserTypes
            {
                Id = 1,
                Description = "",
                Name = ""
            });
            _context.UserTypes.Add(new UserTypes
            {
                Id = 2,
                Description = "",
                Name = ""
            });
            _context.SaveChanges();
            _userTypesService = new UserTypesService(_context, _mapper);

            // Act
            var list = _userTypesService.Get();
            // Assert
            Assert.IsType<List<Model.UserTypes>>(list);
            Assert.Equal(list.Count, _context.UserTypes.Local.Count);
        }
        [Fact]
        public void GetByIdSuccessfullyReturnObject()
        {
            _context.UserTypes.Add(new UserTypes
            {
                Id = 3,
                Description = "",
                Name = ""
            });
            _context.SaveChanges();
            _userTypesService = new UserTypesService(_context, _mapper);
            // Act
            var item = _userTypesService.GetById(3);
            // Assert
            Assert.IsType<Model.UserTypes>(item);
            Assert.NotNull(item);
        }
        [Fact]
        public void GetByIdReturnNullObject()
        {
            // Act
            var item = _userTypesService.GetById(100);
            // Assert
            Assert.Null(item);
        }
        [Fact]
        public void IsAdminSuccessfullyReturnObject()
        {
            _context.UserTypes.Add(new UserTypes
            {
                Id = 4,
                Description = "Admin",
                Name = "Admin"
            });
            _context.SaveChanges();
            _userTypesService = new UserTypesService(_context, _mapper);
            // Act
            var item = _userTypesService.isAdmin(4);
            // Assert
            Assert.NotNull(item);
            Assert.Equal("Admin", item.Name);
        }
        [Fact]
        public void IsAdminFailsReturnNullObject()
        {
            _context.UserTypes.Add(new UserTypes
            {
                Id = 5,
                Description = "Admin",
                Name = "Admin"
            });
            _context.SaveChanges();
            _userTypesService = new UserTypesService(_context, _mapper);
            // Act
            var item = _userTypesService.isAdmin(100);
            // Assert
            Assert.Null(item);
        }
    }
}