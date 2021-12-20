using AutoMapper;
using eNatureBeauty.Model.Requests;
using eNatureBeauty.WebAPI.Database;
using eNatureBeauty.WebAPI.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace eNatureBeauty.Test.Services
{
    public class StoragesServiceTest
    {
        private StoragesService _storagesService;
        private natureBeautyContext _context = new natureBeautyContext();
        private IMapper _mapper;
        public StoragesServiceTest()
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
            _storagesService = new StoragesService(_context, _mapper);
        }

        [Fact]
        public void FilterByStorageNameReturnObject()
        {
            _context.Storages.Add(new Storages
            {
                Id = 1,
                Description = "",
                Address = "",
                Name = "Storage1"
            });
            _context.Storages.Add(new Storages
            {
                Id = 2,
                Description = "",
                Address = "",
                Name = "Storage2"
            });
            _context.SaveChanges();
            _storagesService = new StoragesService(_context, _mapper);

            StoragesSearchRequest request = new StoragesSearchRequest
            {
                Name = "Storage1"
            };

            // Act
            var list = _storagesService.Get(request);
            // Assert
            Assert.IsType<List<Model.Storages>>(list);
            Assert.Single(list);
        }
        [Fact]
        public void FilterByStorageNameButReturnWholeList()
        {
            _context.Storages.Add(new Storages
            {
                Id = 3,
                Description = "",
                Address = "",
                Name = "Storage3"
            });
            _context.SaveChanges();
            _storagesService = new StoragesService(_context, _mapper);
            StoragesSearchRequest request = new StoragesSearchRequest();

            // Act
            var list = _storagesService.Get(request);
            // Assert
            Assert.IsType<List<Model.Storages>>(list);
            Assert.Equal(list.Count, _context.Storages.Local.Count);
        }
        [Fact]
        public void DeleteByIdSuccessfullyReturnObject()
        {
            _context.Storages.Add(new Storages
            {
                Id = 4,
                Description = "",
                Name = "",
                Address = ""
            });
            _context.SaveChanges();
            var oldList = _context.Storages.Local.Count;
            // Act
            _storagesService.Delete(4);
            // Assert
            Assert.Equal(oldList - 1, _context.Storages.Local.Count);
        }
        [Fact]
        public void DeleteByIdReturnNullException()
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => _storagesService.Delete(100));
        }
        [Fact]
        public void GetByIdSuccessfullyReturnObject()
        {
            // Act
            var item = _storagesService.GetById(1);
            // Assert
            Assert.IsType<Model.Storages>(item);
            Assert.NotNull(item);
        }
        [Fact]
        public void GetByIdReturnNullObject()
        {
            // Act
            var item = _storagesService.GetById(100);
            // Assert
            Assert.Null(item);
        }
        [Fact]
        public void InsertItemSuccessfullyReturnObject()
        {
            var request = new StoragesUpsertRequest
            {
                Id = 5,
                Address = "",
                Description = "",
                Name = ""
            };
            //Act
            var oldList = _context.Storages.Local.Count;
            _storagesService.Insert(request);
            //Assert
            Assert.Equal(oldList + 1, _context.Storages.Local.Count);
        }

        [Fact]
        public void UpdateItemSuccessfullyReturnObject()
        {
            _context.Storages.Add(new Storages
            {
                Id = 6,
                Description = "",
                Address = "",
                Name = ""
            });
            _context.SaveChanges();
            _storagesService = new StoragesService(_context, _mapper);
            var request = new StoragesUpsertRequest
            {
                Id = 6,
                Address = "",
                Description = "",
                Name = ""
            };
            //Act
            _storagesService.Update(6, request);
            var item = _storagesService.GetById(6);
            //Assert
            Assert.Equal(request.Description, item.Description);
        }
    }
}
