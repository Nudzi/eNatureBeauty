using AutoMapper;
using eNatureBeauty.Model.Requests.Orders;
using eNatureBeauty.WebAPI.Database;
using eNatureBeauty.WebAPI.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Xunit;

namespace eNatureBeauty.Test.Services
{
    public class OrdersServiceTest
    {
        private OrdersService _ordersService;
        private natureBeautyContext _context = new natureBeautyContext();
        private IMapper _mapper;
        public OrdersServiceTest()
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
            _ordersService = new OrdersService(_context, _mapper);
        }

        [Fact]
        public void FilterByUserId_ReturnObject()
        {
            _context.Orders.Add(new Orders
            {
                Id = 1,
                OrderNumber = "",
                Date = DateTime.Now,
                Status = "",
                UserId = 1
            });
            _context.Orders.Add(new Orders
            {
                Id = 2,
                OrderNumber = "",
                Date = DateTime.Now,
                Status = "",
                UserId = 2
            });
            _context.SaveChanges();
            _ordersService = new OrdersService(_context, _mapper);
            OrdersSearchRequest request = new OrdersSearchRequest
            {
                UserId = 1
            };
            // Act
            var list = _ordersService.Get(request);
            // Assert
            Assert.IsType<List<Model.Orders>>(list);
            Assert.Single(list);
        }
        [Fact]
        public void FilterByOrderNumber_ReturnObject()
        {
            _context.Orders.Add(new Orders
            {
                Id = 3,
                OrderNumber = "3",
                Date = DateTime.Now,
                Status = "",
                UserId = 3
            });
            _context.Orders.Add(new Orders
            {
                Id = 4,
                OrderNumber = "4",
                Date = DateTime.Now,
                Status = "",
                UserId = 4
            });
            _context.SaveChanges();
            _ordersService = new OrdersService(_context, _mapper);
            OrdersSearchRequest request = new OrdersSearchRequest
            {
                OrderNumber = "4"
            };
            // Act
            var list = _ordersService.Get(request);
            // Assert
            Assert.IsType<List<Model.Orders>>(list);
            Assert.Single(list);
        }
        [Fact]
        public void FilterEmpty_ReturnWholeList()
        {
            _context.Orders.Add(new Orders
            {
                Id = 5,
                OrderNumber = "5",
                Date = DateTime.Now,
                Status = "",
                UserId = 5
            });
            _context.SaveChanges();
            _ordersService = new OrdersService(_context, _mapper);
            OrdersSearchRequest request = new OrdersSearchRequest();
            // Act
            var list = _ordersService.Get(request);
            // Assert
            Assert.IsType<List<Model.Orders>>(list);
            Assert.Equal(list.Count, _context.Orders.Local.Count);
        }
        [Fact]
        public void FilterByUserIdAndOrderNumber_ReturnEmpty()
        {
            _context.Orders.Add(new Orders
            {
                Id = 6,
                OrderNumber = "6",
                Date = DateTime.Now,
                Status = "",
                UserId = 6
            });
            _context.SaveChanges();
            _ordersService = new OrdersService(_context, _mapper);
            OrdersSearchRequest request = new OrdersSearchRequest
            {
                UserId = 7,
                OrderNumber = "7"
            };
            // Act
            var list = _ordersService.Get(request);
            // Assert
            Assert.IsType<List<Model.Orders>>(list);
            Assert.Empty(list);
        }
        [Fact]
        public void FilterByUserIdAndOrderNumber_ReturnObject()
        {
            _context.Orders.Add(new Orders
            {
                Id = 8,
                OrderNumber = "8",
                Date = DateTime.Now,
                Status = "",
                UserId = 8
            });
            _context.SaveChanges();
            _ordersService = new OrdersService(_context, _mapper);
            OrdersSearchRequest request = new OrdersSearchRequest
            {
                UserId = 8,
                OrderNumber = "8"
            };
            // Act
            var list = _ordersService.Get(request);
            // Assert
            Assert.IsType<List<Model.Orders>>(list);
            Assert.Single(list);
        }
    }
}
