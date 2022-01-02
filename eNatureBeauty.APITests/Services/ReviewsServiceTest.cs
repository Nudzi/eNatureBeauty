using AutoMapper;
using eNatureBeauty.Model.Requests;
using eNatureBeauty.WebAPI.Database;
using eNatureBeauty.WebAPI.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Xunit;

namespace eNatureBeauty.Test.Services
{
    public class ReviewsServiceTest
    {
        private ReviewsService _reviewsService;
        private natureBeautyContext _context = new natureBeautyContext();
        private IMapper _mapper;

        public ReviewsServiceTest()
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
            _reviewsService = new ReviewsService(_context, _mapper);
        }
        [Fact]
        public void GetReviewByProductId_ReturnObject()
        {
            ReviewsSearchRequest request = new ReviewsSearchRequest
            {
                ProductId = 1
            };
            _context.Reviews.Add(
                new Reviews
                {
                    Id = 1,
                    Description = "",
                    ProductId = 1,
                    Review = 1,
                    UserId = 1
                }
            );
            _context.Reviews.Add(
                new Reviews
                {
                    Id = 2,
                    Description = "",
                    ProductId = 2,
                    Review = 2,
                    UserId = 2
                }
            );
            _context.SaveChanges();
            _reviewsService = new ReviewsService(_context, _mapper);
            //Act
            var list = _reviewsService.Get(request);
            //Assert
            Assert.IsType<List<Model.Reviews.Reviews>>(list);
            Assert.Single(list);
        }
        [Fact]
        public void GetReviewByUserId_ReturnObject()
        {
            ReviewsSearchRequest request = new ReviewsSearchRequest
            {
                UserId = 3
            };
            _context.Reviews.Add(
                new Reviews
                {
                    Id = 3,
                    Description = "",
                    ProductId = 3,
                    Review = 3,
                    UserId = 3
                }
            );
            _context.Reviews.Add(
                new Reviews
                {
                    Id = 4,
                    Description = "",
                    ProductId = 4,
                    Review = 4,
                    UserId = 4
                }
            );
            _context.SaveChanges();
            _reviewsService = new ReviewsService(_context, _mapper);
            //Act
            var list = _reviewsService.Get(request);
            //Assert
            Assert.IsType<List<Model.Reviews.Reviews>>(list);
            Assert.Single(list);
        }
        [Fact]
        public void DeleteByIdSucessfully_ReturnObject()
        {
            _context.Reviews.Add(
                 new Reviews
                 {
                     Id = 5,
                     Description = "",
                     ProductId = 5,
                     Review = 5,
                     UserId = 5
                 }
             );
            _context.SaveChanges();
            var oldList = _context.Reviews.Local.Count;
            // Act
            _reviewsService.Delete(5);
            // Assert
            Assert.Equal(oldList - 1, _context.Reviews.Local.Count);
        }
        [Fact]
        public void DeleteById_ReturnNullException()
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => _reviewsService.Delete(100));
        }
        [Fact]
        public void GetByIdSuccessfully_ReturnObject()
        {
            _context.Reviews.Add(
                 new Reviews
                 {
                     Id = 9,
                     Description = "",
                     ProductId = 9,
                     Review = 9,
                     UserId = 9
                 }
             );
            _context.SaveChanges();
            _reviewsService = new ReviewsService(_context, _mapper);

            // Act
            var item = _reviewsService.GetById(9);
            // Assert
            Assert.IsType<Model.Reviews.Reviews>(item);
            Assert.NotNull(item);
        }
        [Fact]
        public void GetById_ReturnNotFound()
        {
            // Act
            var item = _reviewsService.GetById(100);
            // Assert
            Assert.Null(item);
        }
        [Fact]
        public void InsertItemSuccessfully_ReturnObject()
        {
            var request = new ReviewsUpsertRequest
            {
                Id = 6,
                Description = "",
                ProductId = 6,
                Review = 6,
                UserId = 6
            };
            //Act
            var oldList = _context.Reviews.Local.Count;
            _reviewsService.Insert(request);
            //Assert
            Assert.Equal(oldList + 1, _context.Reviews.Local.Count);
        }

        [Fact]
        public void UpdateItemSuccessfully_ReturnObject()
        {
            _context.Reviews.Add(
                 new Reviews
                 {
                     Id = 7,
                     Description = "",
                     ProductId = 7,
                     Review = 7,
                     UserId = 7
                 }
             );
            _context.SaveChanges();
            _reviewsService = new ReviewsService(_context, _mapper);

            var request = new ReviewsUpsertRequest
            {
                Id = 7,
                Description = "Description7",
                ProductId = 7,
                Review = 7,
                UserId = 7
            };
            //Act
            _reviewsService.Update(7, request);
            var item = _reviewsService.GetById(7);
            //Assert
            Assert.Equal(request.Description, item.Description);
        }
    }
}