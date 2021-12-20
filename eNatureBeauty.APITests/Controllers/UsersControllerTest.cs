using eNatureBeauty.Model.Requests;
using eNatureBeauty.WebAPI.Controllers;
using eNatureBeauty.WebAPI.Services;
using System.Collections.Generic;
using Xunit;

namespace eNatureBeauty.APITests.Controllers
{
    public class UsersControllerTest
    {
        private readonly UsersController _controller;
        private IUsersService _service;
        public UsersControllerTest()
        {
            _service = new UsersFakeService();
            _controller = new UsersController(_service);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsListOfObjects()
        {
            UsersSearchRequest request = null;
            // Act
            var list = _controller.Get(request);
            // Assert
            Assert.IsType<List<Model.Users>>(list);
            Assert.Equal(3, list.Count);
        }
        [Fact]
        public void Get_WhenCalledWithFirstName_ReturnsObject()
        {
            UsersSearchRequest request = new UsersSearchRequest { FirstName = "Ime1234" };
            // Act
            var list = _controller.Get(request);
            // Assert
            Assert.IsType<List<Model.Users>>(list);
            Assert.Single(list);
        }
        [Fact]
        public void Get_WhenCalledWithLastName_ReturnsObject()
        {
            UsersSearchRequest request = new UsersSearchRequest { LastName = "Prezime1234" };
            // Act
            var list = _controller.Get(request);
            // Assert
            Assert.IsType<List<Model.Users>>(list);
            Assert.Single(list);
        }
        [Fact]
        public void Get_WhenCalledWithFirstNameAndLastName_ReturnsObject()
        {
            UsersSearchRequest request = new UsersSearchRequest { LastName = "Prezime1234", FirstName = "Ime1234" };
            // Act
            var list = _controller.Get(request);
            // Assert
            Assert.IsType<List<Model.Users>>(list);
            Assert.Single(list);
        }
        [Fact]
        public void Get_WhenCalledWithWrongFirstNameAndLastName_ReturnsEmptyList()
        {
            UsersSearchRequest request = new UsersSearchRequest { LastName = "Prezime12345", FirstName = "Ime12345" };
            // Act
            var list = _controller.Get(request);
            // Assert
            Assert.IsType<List<Model.Users>>(list);
            Assert.Empty(list);
        }
        [Fact]
        public void GetById_WhenCalled_ReturnsObject()
        {
            // Act
            var item = _controller.GetById(12);
            // Assert
            Assert.IsType<Model.Users>(item);
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
        public void Insert_WhenCalled_ReturnsAddedObject()
        {
            var request = new UsersInsertRequest()
            {
                Id = 999,
                Email = "",
                FirstName = "",
                LastName = "",
                UserName = "",
                Telephone = "",
                Password = "Test1",
                PasswordConfirmation = "Test1"
            };
            // Act
            var item = _controller.Insert(request);
            // Assert
            Assert.IsType<Model.Users>(item);
            Assert.NotNull(item);
        }
        [Fact]
        public void Update_WhenCalled_ReturnsAddedObject()
        {
            var request = new UsersInsertRequest()
            {
                Id = 12,
                Email = "",
                FirstName = "Novo Ime12",
                LastName = "",
                UserName = "",
                Telephone = "",
                Password = "Test1",
                PasswordConfirmation = "Test1"
            };
            // Act
            _controller.Update(12, request);
            var item = _controller.GetById(12);
            // Assert
            Assert.IsType<Model.Users>(item);
            Assert.Equal("Novo Ime12", item.FirstName);
        }
        [Fact]
        public void Authentication_WhenCalledWithWrongUserNameAndPass_ReturnsNull()
        {
            var request = new UsersInsertRequest()
            {
                Id = 12,
                Email = "",
                FirstName = "Novo Ime12",
                LastName = "",
                UserName = "",
                Telephone = "",
                Password = "Test1",
                PasswordConfirmation = "Test1"
            };
            // Act
            var item = _controller.Authentication("Test", "Test");
            // Assert
            Assert.Null(item);
        }
        [Fact]
        public void Authentication_WhenCalledWithCorrectUserNameAndPass_ReturnsObject()
        {
            var request = new UsersInsertRequest()
            {
                Id = 12,
                Email = "",
                FirstName = "Ime123",
                LastName = "",
                UserName = "",
                Telephone = "",
                Password = "Test1",
                PasswordConfirmation = "Test1"
            };
            // Act
            var item = _controller.Authentication("Ime123", "Test");
            // Assert
            Assert.Equal("Ime123", item.UserName);
        }
    }
}
