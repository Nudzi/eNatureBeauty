using eNatureBeauty.Model.Requests;
using eNatureBeauty.WebAPI.Controllers;
using eNatureBeauty.WebAPI.Services;
using System.Collections.Generic;
using Xunit;

namespace eNatureBeauty.APITests.Controllers
{
    public class WishlistsControllerTest
    {
        private readonly WishlistsController _controller;
        private IWishlistsService _service;
        public WishlistsControllerTest()
        {
            _service = new WishlistsServiceBuilder();
            _controller = new WishlistsController(_service);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsListOfObjects()
        {
            WishlistsSearchRequest request = new WishlistsSearchRequest
            {
                ProductId = 1
            };
            // Act
            var list = _controller.Get(request);
            // Assert
            Assert.IsType<List<Model.Wishlists>>(list);
        }
        [Fact]
        public void Get_WhenCalledWithProductId_ReturnsObject()
        {
            WishlistsSearchRequest request = new WishlistsSearchRequest { ProductId = 1 };
            // Act
            var list = _controller.Get(request);
            // Assert
            Assert.IsType<List<Model.Wishlists>>(list);
            Assert.Single(list);
        }
        [Fact]
        public void Get_WhenCalledWithUserId_ReturnsObject()
        {
            WishlistsSearchRequest request = new WishlistsSearchRequest { UserId = 1 };
            // Act
            var list = _controller.Get(request);
            // Assert
            Assert.IsType<List<Model.Wishlists>>(list);
            Assert.Single(list);
        }
        [Fact]
        public void Get_WhenCalledWithUserIdAndProductId_ReturnsObject()
        {
            WishlistsSearchRequest request = new WishlistsSearchRequest { UserId = 1, ProductId = 1 };
            // Act
            var list = _controller.Get(request);
            // Assert
            Assert.IsType<List<Model.Wishlists>>(list);
            Assert.Single(list);
        }
        [Fact]
        public void Get_WhenCalledWithWrongFirstNameAndLastName_ReturnsEmptyList()
        {
            WishlistsSearchRequest request = new WishlistsSearchRequest { ProductId = 1234, UserId = 1234 };
            // Act
            var list = _controller.Get(request);
            // Assert
            Assert.IsType<List<Model.Wishlists>>(list);
            Assert.Empty(list);
        }
        [Fact]
        public void GetById_WhenCalled_ReturnsObject()
        {
            // Act
            var item = _controller.GetById(2);
            // Assert
            Assert.IsType<Model.Wishlists>(item);
            Assert.NotNull(item);
        }
        [Fact]
        public void GetById_WhenCalled_ReturnsNullObject()
        {
            // Act
            var item = _controller.GetById(123456);
            // Assert
            Assert.Null(item);
        }
        [Fact]
        public void Insert_WhenCalled_ReturnsSameListSize()
        {
            var request = new WishlistsUpsertRequest
            {
                Id = 9,
                Description = "",
                ProductId = 9,
                UserId = 9
            };
            // Act
            var oldList = _controller.Get(null).Count;
            _controller.Insert(request);
            var newList = _controller.Get(null).Count;
            // Assert
            Assert.Equal(oldList + 1, newList);
        }
        [Fact]
        public void Update_WhenCalled_ReturnsAddedObject()
        {
            var request = new WishlistsUpsertRequest
            {
                Id = 1,
                Description = "New",
                ProductId = 9,
                UserId = 9
            };
            // Act
            _controller.Update(1, request);
            var item = _controller.GetById(1);

            // Assert
            Assert.Equal("New", item.Description);
        }
        [Fact]
        public void Delete_WhenCalled_ReturnsSuccessfulDelete()
        {
            var oldList = _controller.Get(null).Count;
            // Act
            _controller.Delete(1);
            var newList = _controller.Get(null).Count;

            // Assert
            Assert.Equal(oldList - 1, newList);
        }
    }
}
