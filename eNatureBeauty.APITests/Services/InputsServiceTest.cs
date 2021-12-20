using AutoMapper;
using eNatureBeauty.Model.Requests.Inputs;
using eNatureBeauty.WebAPI.Database;
using eNatureBeauty.WebAPI.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Xunit;

namespace eNatureBeauty.Test.Services
{
    public class InputsServiceTest
    {
        private InputsService _ordersService;
        private natureBeautyContext _context = new natureBeautyContext();
        private IMapper _mapper;
        public InputsServiceTest()
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
            _ordersService = new InputsService(_context, _mapper);
        }

        [Fact]
        public void FilterByInvoiceNumberReturnObject()
        {
            _context.Inputs.Add(new Inputs
            {
                Id = 1,
                Date = DateTime.Now,
                UserId = 1,
                InvoiceAmount = 0,
                InvoiceAmountWithPdv = 0,
                InvoiceNumber = "1",
                Note = "",
                Pdv = 0,
                StorageId = 1
            });
            _context.Inputs.Add(new Inputs
            {
                Id = 2,
                Date = DateTime.Now,
                UserId = 2,
                InvoiceAmount = 0,
                InvoiceAmountWithPdv = 0,
                InvoiceNumber = "2",
                Note = "",
                Pdv = 0,
                StorageId = 1
            });
            _context.SaveChanges();
            _ordersService = new InputsService(_context, _mapper);
            InputsSearchRequest request = new InputsSearchRequest
            {
                InvoiceNumber = "2"
            };
            // Act
            var list = _ordersService.Get(request);
            // Assert
            Assert.IsType<List<Model.Inputs>>(list);
            Assert.Single(list);
        }
        [Fact]
        public void FilterByInvoiceNumberReturnEmpty()
        {
            _context.Inputs.Add(new Inputs
            {
                Id = 3,
                Date = DateTime.Now,
                UserId = 3,
                InvoiceAmount = 0,
                InvoiceAmountWithPdv = 0,
                InvoiceNumber = "3",
                Note = "",
                Pdv = 0,
                StorageId = 1
            });
            _context.SaveChanges();
            _ordersService = new InputsService(_context, _mapper);
            InputsSearchRequest request = new InputsSearchRequest
            {
                InvoiceNumber = "100"
            };
            // Act
            var list = _ordersService.Get(request);
            // Assert
            Assert.IsType<List<Model.Inputs>>(list);
            Assert.Empty(list);
        }
        [Fact]
        public void FilterEmptyReturnWholeList()
        {
            _context.Inputs.Add(new Inputs
            {
                Id = 4,
                Date = DateTime.Now,
                UserId = 4,
                InvoiceAmount = 0,
                InvoiceAmountWithPdv = 0,
                InvoiceNumber = "4",
                Note = "",
                Pdv = 0,
                StorageId = 1
            });
            _context.SaveChanges();
            _ordersService = new InputsService(_context, _mapper);
            InputsSearchRequest request = new InputsSearchRequest();
            // Act
            var list = _ordersService.Get(request);
            // Assert
            Assert.IsType<List<Model.Inputs>>(list);
            Assert.Equal(list.Count, _context.Inputs.Local.Count);
        }
    }
}
