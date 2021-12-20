using AutoMapper;
using eNatureBeauty.Model.Requests;
using eNatureBeauty.Model.Requests.UserAddresses;
using eNatureBeauty.WebAPI.Database;
using eNatureBeauty.WebAPI.Filters;
using eNatureBeauty.WebAPI.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Xunit;

namespace eNatureBeauty.Test.Services
{
    public class UserAddressesServiceTest
    {
        private UserAddressesService _userAddressesService;
        private natureBeautyContext _context = new natureBeautyContext();
        private IMapper _mapper;
        public UserAddressesServiceTest()
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
            _userAddressesService = new UserAddressesService(_context, _mapper);
        }

        [Fact]
        public void FilterByAddressNameReturnObject()
        {
            _context.UserAddresses.Add(new UserAddresses
            {
                Id = 1,
                AddressName = "Test1",
                City = "",
                Country = ""
            });
            _context.UserAddresses.Add(new UserAddresses
            {
                Id = 2,
                AddressName = "Test2",
                City = "",
                Country = ""
            });
            _context.SaveChanges();
            _userAddressesService = new UserAddressesService(_context, _mapper);
            UserAddressesSearchRequest request = new UserAddressesSearchRequest
            {
                AddressName = "Test1"
            };
            // Act
            var list = _userAddressesService.Get(request);
            // Assert
            Assert.IsType<List<Model.UserAddresses>>(list);
            Assert.Single(list);
        }
        [Fact]
        public void FilterByCountryReturnObject()
        {
            _context.UserAddresses.Add(new UserAddresses
            {
                Id = 3,
                AddressName = "",
                City = "",
                Country = "Country3"
            });
            _context.SaveChanges();
            _userAddressesService = new UserAddressesService(_context, _mapper);
            UserAddressesSearchRequest request = new UserAddressesSearchRequest
            {
                Country = "Country3"
            };
            // Act
            var list = _userAddressesService.Get(request);
            // Assert
            Assert.IsType<List<Model.UserAddresses>>(list);
            Assert.Single(list);
        }
        [Fact]
        public void FilterByAddressNameAndCountryReturnObject()
        {
            _context.UserAddresses.Add(new UserAddresses
            {
                Id = 4,
                AddressName = "Address4",
                City = "",
                Country = "Country4"
            });
            _context.SaveChanges();
            _userAddressesService = new UserAddressesService(_context, _mapper);
            UserAddressesSearchRequest request = new UserAddressesSearchRequest
            {
                Country = "Country4",
                AddressName = "Address4"
            };
            // Act
            var list = _userAddressesService.Get(request);
            // Assert
            Assert.IsType<List<Model.UserAddresses>>(list);
            Assert.Single(list);
        }
        [Fact]
        public void FilterEmptyReturnWholeList()
        {
            UserAddressesSearchRequest request = new UserAddressesSearchRequest();
            // Act
            var list = _userAddressesService.Get(request);
            // Assert
            Assert.IsType<List<Model.UserAddresses>>(list);
            Assert.Equal(list.Count, _context.UserAddresses.Local.Count);
        }
    }
}