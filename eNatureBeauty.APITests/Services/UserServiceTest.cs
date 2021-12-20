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
    public class UserServiceTest
    {
        private UsersService _usersService;
        private natureBeautyContext _context = new natureBeautyContext();
        private IMapper _mapper;
        public UserServiceTest()
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
            _usersService = new UsersService(_context, _mapper);
        }

        [Fact]
        public void FilterUserByFirstNameReturnObject()
        {
            _context.Users.Add(new Users
            {
                Id = 15,
                FirstName = "Ime15",
                LastName = "Prezime15",
                UserAddressId = 1,
                Email = "",
                Telephone = "",
                UserName = "",
                PasswordHash = "",
                PasswordSalt = ""
            });
            _context.Users.Add(new Users
            {
                Id = 28,
                FirstName = "Ime2",
                LastName = "Prezime2",
                UserAddressId = 28,
                Email = "",
                Telephone = "",
                UserName = "",
                PasswordHash = "",
                PasswordSalt = ""
            });
            _context.SaveChanges();
            _usersService = new UsersService(_context, _mapper);

            UsersSearchRequest request = new UsersSearchRequest
            {
                FirstName = "Ime15",
                LastName = ""
            };

            // Act
            var listUsers = _usersService.Get(request);
            // Assert
            Assert.IsType<List<Model.Users>>(listUsers);
            Assert.Single(listUsers);
        }

        [Fact]
        public void FilterUserByLastNameReturnObject()
        {
            _context.Users.Add(new Users
            {
                Id = 3,
                FirstName = "",
                LastName = "Prezime3",
                UserAddressId = 1,
                Email = "",
                Telephone = "",
                UserName = "",
                PasswordHash = "",
                PasswordSalt = ""
            });
            _context.SaveChanges();
            _usersService = new UsersService(_context, _mapper);
            UsersSearchRequest request = new UsersSearchRequest
            {
                LastName = "Prezime3"
            };

            // Act
            var listUsers = _usersService.Get(request);
            // Assert
            Assert.IsType<List<Model.Users>>(listUsers);
            Assert.Single(listUsers);
        }
        [Fact]
        public void UserRequestIsEmptyReturnWholeList()
        {
            _usersService = new UsersService(_context, _mapper);
            UsersSearchRequest request = new UsersSearchRequest();

            // Act
            var listUsers = _usersService.Get(request);
            // Assert
            Assert.IsType<List<Model.Users>>(listUsers);
            Assert.Equal(listUsers.Count, _context.Users.Local.Count);
        }

        [Fact]
        public void UserRequestIsNotEmptyButZeroUserList()
        {
            UsersSearchRequest request = new UsersSearchRequest
            {
                FirstName = "Random",
                LastName = "Random"
            };

            // Act
            var listUsers = _usersService.Get(request);
            // Assert
            Assert.IsType<List<Model.Users>>(listUsers);
            Assert.Empty(listUsers);
        }
        //[Trait("Users List Tests1", "GetById")]
        [Fact]
        public void GetUserByIdSucessfullyReturnObject()
        {
            _context.Users.Add(new Users
            {
                Id = 23,
                FirstName = "",
                LastName = "Prezime3",
                UserAddressId = 1,
                Email = "",
                Telephone = "",
                UserName = "",
                PasswordHash = "",
                PasswordSalt = ""
            });
            _context.SaveChanges();
            _usersService = new UsersService(_context, _mapper);
            // Act
            var user = _usersService.GetById(23);
            // Assert
            Assert.IsType<Model.Users>(user);
            Assert.Equal(23, user.Id);
        }
        [Fact]
        public void GetUserByIdReturnNotFound()
        {
            // Act
            var user = _usersService.GetById(100);
            // Assert
            Assert.Null(user);
        }
        [Fact]
        public void InsertButReturnPasswordsDontMatch()
        {
            var request = new UsersInsertRequest()
            {
                Email = "",
                FirstName = "",
                LastName = "",
                UserName = "",
                Telephone = "",
                Password = "Test1",
                PasswordConfirmation = "Test2"
            };
            // Assert
            Assert.Throws<UserException>(() => _usersService.Insert(request));
        }
        [Fact]
        public void InsertUserSucessfullyReturnObject()
        {
            var request = new UsersInsertRequest()
            {
                Email = "",
                FirstName = "",
                LastName = "",
                UserName = "",
                Telephone = "",
                Password = "Test1",
                PasswordConfirmation = "Test1"
            };
            //Act
            var oldListCount = _context.Users.Local.Count;
            _usersService.Insert(request);
            // Assert
            Assert.Equal(oldListCount + 1, _context.Users.Local.Count);
        }
        [Fact]
        public void InsertUserSucessfullyReturnWithUserType()
        {
            var userTypes = new List<int>() { 1 };
            var request = new UsersInsertRequest()
            {
                Email = "",
                FirstName = "",
                LastName = "",
                UserName = "",
                Telephone = "",
                Password = "Test1",
                PasswordConfirmation = "Test1",
                UserTypes = userTypes
            };
            //Act
            var oldListCount = _context.Users.Local.Count;
            _usersService.Insert(request);
            // Assert
            Assert.Equal(oldListCount + 1, _context.Users.Local.Count);
            Assert.Single(_context.UsersUserTypes.Local);
        }
        [Fact]
        public void UpdateButReturnPasswordsDontMatch()
        {
            var request = new UsersInsertRequest()
            {
                Email = "",
                FirstName = "",
                LastName = "",
                UserName = "",
                Telephone = "",
                Password = "Test1",
                PasswordConfirmation = "Test2"
            };
            // Assert
            Assert.Throws<Exception>(() => _usersService.Update(1, request));
        }
        [Fact]
        public void UpdateButReturnUserNull() //I found error on NULL user
        {
            var request = new UsersInsertRequest()
            {
                Email = "",
                FirstName = "",
                LastName = "",
                UserName = "",
                Telephone = "",
                Password = "Test1",
                PasswordConfirmation = "Test1"
            };
            // Assert
            Assert.Throws<NullReferenceException>(() => _usersService.Update(100, request));
        }
        [Fact]
        public void UpdateFirstNameSuccessfullyReturnObject()
        {
            _context.Users.Add(new Users
            {
                Id = 233,
                FirstName = "",
                LastName = "Prezime3",
                UserAddressId = 1,
                Email = "",
                Telephone = "",
                UserName = "",
                PasswordHash = "",
                PasswordSalt = ""
            });
            _context.SaveChanges();
            var request = new UsersInsertRequest()
            {
                Id = 233,
                Email = "",
                FirstName = "New Name Test",
                LastName = "",
                UserName = "",
                Telephone = "",
                Password = "Test1",
                PasswordConfirmation = "Test1"
            };
            _usersService = new UsersService(_context, _mapper);
            // Assert
            var user = _usersService.Update(233, request);
            Assert.Equal("New Name Test", user.FirstName);
        }
    }
}