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
    public class WishlistsServiceTest
    {
        private WishlistsService _wishlistsService;
        private natureBeautyContext _context = new natureBeautyContext();
        private IMapper _mapper;
        public WishlistsServiceTest()
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
            _wishlistsService = new WishlistsService(_context, _mapper);
        }

        [Fact]
        public void FilterByProductIdReturnObject()
        {
            _context.Wishlists.Add(new Wishlists
            {
                Id = 1,
                Description = "",
                ProductId = 1,
                UserId = 1
            });
            _context.Wishlists.Add(new Wishlists
            {
                Id = 2,
                Description = "",
                ProductId = 2,
                UserId = 2
            });
            _context.SaveChanges();
            _wishlistsService = new WishlistsService(_context, _mapper);

            WishlistsSearchRequest request = new WishlistsSearchRequest
            {
                ProductId = 1
            };

            // Act
            var list = _wishlistsService.Get(request);
            // Assert
            Assert.IsType<List<Model.Wishlists>>(list);
            Assert.Single(list);
        }
        [Fact]
        public void FilterByUserIdReturnObject()
        {
            _context.Wishlists.Add(new Wishlists
            {
                Id = 3,
                Description = "",
                ProductId = 3,
                UserId = 3
            });
            _context.Wishlists.Add(new Wishlists
            {
                Id = 4,
                Description = "",
                ProductId = 4,
                UserId = 4
            });
            _context.SaveChanges();
            _wishlistsService = new WishlistsService(_context, _mapper);

            WishlistsSearchRequest request = new WishlistsSearchRequest
            {
                UserId = 4
            };

            // Act
            var list = _wishlistsService.Get(request);
            // Assert
            Assert.IsType<List<Model.Wishlists>>(list);
            Assert.Single(list);
        }
        [Fact]
        public void FilterByProductIdAndUserIdReturnObject()
        {
            _context.Wishlists.Add(new Wishlists
            {
                Id = 5,
                Description = "",
                ProductId = 5,
                UserId = 5
            });
            _context.Wishlists.Add(new Wishlists
            {
                Id = 6,
                Description = "",
                ProductId = 6,
                UserId = 6
            });
            _context.SaveChanges();
            _wishlistsService = new WishlistsService(_context, _mapper);

            WishlistsSearchRequest request = new WishlistsSearchRequest
            {
                ProductId = 5,
                UserId = 5
            };

            // Act
            var list = _wishlistsService.Get(request);
            // Assert
            Assert.IsType<List<Model.Wishlists>>(list);
            Assert.Single(list);
        }
        [Fact]
        public void FilterButReturnWholeList()
        {
            _context.Wishlists.Add(new Wishlists
            {
                Id = 7,
                Description = "",
                ProductId= 7,
                UserId = 7
            });
            _context.SaveChanges();
            _wishlistsService = new WishlistsService(_context, _mapper);
            WishlistsSearchRequest request = new WishlistsSearchRequest();

            // Act
            var list = _wishlistsService.Get(request);
            // Assert
            Assert.IsType<List<Model.Wishlists>>(list);
            Assert.Equal(list.Count, _context.Wishlists.Local.Count);
        }
        [Fact]
        public void DeleteByIdSuccessfullyReturnEqualListSizes()
        {
            _context.Wishlists.Add(new Wishlists
            {
                Id = 8,
                Description = "",
                ProductId = 8,
                UserId = 8
            });
            _context.SaveChanges();
            _wishlistsService = new WishlistsService(_context, _mapper);
            var oldList = _context.Wishlists.Local.Count;
            // Act
            _wishlistsService.Delete(8);
            // Assert
            Assert.Equal(oldList - 1, _context.Wishlists.Local.Count);
        }
        [Fact]
        public void DeleteByIdReturnNullException()
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => _wishlistsService.Delete(100));
        }
        [Fact]
        public void GetByIdSuccessfullyReturnObject()
        {
            _context.Wishlists.Add(new Wishlists
            {
                Id = 88,
                Description = "",
                ProductId = 88,
                UserId = 88
            });
            _context.SaveChanges();
            _wishlistsService = new WishlistsService(_context, _mapper);

            // Act
            var item = _wishlistsService.GetById(88);
            // Assert
            Assert.IsType<Model.Wishlists>(item);
            Assert.NotNull(item);
        }
        [Fact]
        public void GetByIdReturnNullObject()
        {
            // Act
            var item = _wishlistsService.GetById(100);
            // Assert
            Assert.Null(item);
        }
        [Fact]
        public void InsertItemSuccesfully()
        {
            var request = new WishlistsUpsertRequest
            {
                Id = 9,
                Description = "",
                ProductId = 9,
                UserId = 9
            };
            //Act
            var oldList = _context.Wishlists.Local.Count;
            _wishlistsService.Insert(request);
            //Assert
            Assert.Equal(oldList + 1, _context.Wishlists.Local.Count);
        }

        [Fact]
        public void UpdateItemSuccessfullyReturnObject()
        {
            _context.Wishlists.Add(new Wishlists
            {
                Id = 10,
                Description = "",
                ProductId = 10,
                UserId = 10
            });
            _context.SaveChanges();
            _wishlistsService = new WishlistsService(_context, _mapper);
            var request = new WishlistsUpsertRequest
            {
                Id = 10,
                Description = "",
                ProductId = 10,
                UserId = 10
            };
            //Act
            _wishlistsService.Update(10, request);
            var item = _wishlistsService.GetById(10);
            //Assert
            Assert.Equal(request.Description, item.Description);
        }
    }
}
