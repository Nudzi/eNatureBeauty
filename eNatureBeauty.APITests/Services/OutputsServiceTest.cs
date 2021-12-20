using AutoMapper;
using eNatureBeauty.Model.Requests.Outputs;
using eNatureBeauty.WebAPI.Database;
using eNatureBeauty.WebAPI.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Xunit;

namespace eNatureBeauty.Test.Services
{
    public class OutputsServiceTest
    {
        private OutputsService _outputsService;
        private natureBeautyContext _context = new natureBeautyContext();
        private IMapper _mapper;
        public OutputsServiceTest()
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
            _outputsService = new OutputsService(_context, _mapper);
        }

        [Fact]
        public void FilterByOrderIdReturnObject()
        {
            _context.Outputs.Add(new Outputs
            {
                Id = 1,
                Date = DateTime.Now,
                Finished = false,
                OrderId = 1,
                ReceiveNumber = "",
                UserId = 1,
                ValueWithoutPdv  = 1,
                ValueWithPdv = 1
            });
            _context.Outputs.Add(new Outputs
            {
                Id = 2,
                Date = DateTime.Now,
                Finished = false,
                OrderId = 2,
                ReceiveNumber = "",
                UserId = 2,
                ValueWithoutPdv = 1,
                ValueWithPdv = 1
            });
            _context.SaveChanges();
            _outputsService = new OutputsService(_context, _mapper);
            OutputsSearchRequest request = new OutputsSearchRequest
            {
                OrderId = 1
            };
            // Act
            var list = _outputsService.Get(request);
            // Assert
            Assert.IsType<List<Model.Outputs>>(list);
            Assert.Single(list);
        }
        [Fact]
        public void FilterByReceiveNumberReturnObject()
        {
            _context.Outputs.Add(new Outputs
            {
                Id = 3,
                Date = DateTime.Now,
                Finished = false,
                OrderId = 3,
                ReceiveNumber = "3",
                UserId = 1,
                ValueWithoutPdv = 1,
                ValueWithPdv = 1
            });
            _context.Outputs.Add(new Outputs
            {
                Id = 4,
                Date = DateTime.Now,
                Finished = false,
                OrderId = 4,
                ReceiveNumber = "4",
                UserId = 1,
                ValueWithoutPdv = 1,
                ValueWithPdv = 1
            });
            _context.SaveChanges();
            _outputsService = new OutputsService(_context, _mapper);
            OutputsSearchRequest request = new OutputsSearchRequest
            {
                ReceiveNumber = "3"
            };
            // Act
            var list = _outputsService.Get(request);
            // Assert
            Assert.IsType<List<Model.Outputs>>(list);
            Assert.Single(list);
        }
        [Fact]
        public void FilterEmptyReturnWholeList()
        {
            _context.Outputs.Add(new Outputs
            {
                Id = 5,
                Date = DateTime.Now,
                Finished = false,
                OrderId = 5,
                ReceiveNumber = "5",
                UserId = 1,
                ValueWithoutPdv = 1,
                ValueWithPdv = 1
            });
            _context.SaveChanges();
            _outputsService = new OutputsService(_context, _mapper);
            OutputsSearchRequest request = new OutputsSearchRequest();
            // Act
            var list = _outputsService.Get(request);
            // Assert
            Assert.IsType<List<Model.Outputs>>(list);
            Assert.Equal(list.Count, _context.Outputs.Local.Count);
        }
        [Fact]
        public void FilterByReceiveNumberAndOrderIdReturnEmpty()
        {
            _context.Outputs.Add(new Outputs
            {
                Id = 6,
                Date = DateTime.Now,
                Finished = false,
                OrderId = 6,
                ReceiveNumber = "6",
                UserId = 1,
                ValueWithoutPdv = 1,
                ValueWithPdv = 1
            });
            _context.SaveChanges();
            _outputsService = new OutputsService(_context, _mapper);
            OutputsSearchRequest request = new OutputsSearchRequest
            {
                ReceiveNumber = "7",
                OrderId = 7
            };
            // Act
            var list = _outputsService.Get(request);
            // Assert
            Assert.IsType<List<Model.Outputs>>(list);
            Assert.Empty(list);
        }
        [Fact]
        public void FilterByReceiveNumberAndOrderIdReturnObject()
        {
            _context.Outputs.Add(new Outputs
            {
                Id = 8,
                Date = DateTime.Now,
                Finished = false,
                OrderId = 8,
                ReceiveNumber = "8",
                UserId = 1,
                ValueWithoutPdv = 1,
                ValueWithPdv = 1
            });
            _context.SaveChanges();
            _outputsService = new OutputsService(_context, _mapper);
            OutputsSearchRequest request = new OutputsSearchRequest
            {
                ReceiveNumber = "8",
                OrderId = 8
            };
            // Act
            var list = _outputsService.Get(request);
            // Assert
            Assert.IsType<List<Model.Outputs>>(list);
            Assert.Single(list);
        }
    }
}
