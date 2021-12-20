using eNatureBeauty.Model;
using eNatureBeauty.Model.Requests;
using eNatureBeauty.WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eNatureBeauty.APITests.Controllers
{
    public class WishlistsServiceBuilder : IWishlistsService
    {
        private readonly List<Wishlists> _list;
        public WishlistsServiceBuilder()
        {
            _list = new List<Wishlists>()
            {
                new Wishlists()
                {
                    Id = 2,
                Description = "",
                ProductId = 2,
                UserId = 2
                },
                new Wishlists()
                {
                    Id = 1,
                Description = "",
                ProductId = 1,
                UserId = 1
                },
                new Wishlists()
                {
                    Id = 3,
                Description = "",
                ProductId = 3,
                UserId = 3
                }
            };
        }

        public void Delete(int id)
        {
            var existing = _list.First(a => a.Id == id);
            _list.Remove(existing);
        }

        public List<Wishlists> Get(WishlistsSearchRequest request)
        {
            if (request != null)
            {
                return _list.Where(x => x.ProductId == request?.ProductId || x.UserId == request?.UserId).ToList();
            }
            else
            {
                return _list;
            }
        }

        public Wishlists GetById(int id)
        {
            return _list.Where(item => item.Id == id).FirstOrDefault();
        }

        public void Insert(WishlistsUpsertRequest request)
        {
            var item = new Wishlists
            {
                Id = request.Id,
                Description = request.Description,
                ProductId = request.ProductId,
                UserId = request.UserId
            };

            _list.Add(item);
        }

        public void Update(int id, WishlistsUpsertRequest request)
        {
            var existing = _list.Find(a => a.Id == id);
            _list.Remove(existing);
            var item = new Wishlists
            {
                Id = request.Id,
                Description = request.Description,
                ProductId = request.ProductId,
                UserId = request.UserId
            };

            _list.Add(item);
        }
    }
}