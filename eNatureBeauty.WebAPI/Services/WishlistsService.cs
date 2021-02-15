using AutoMapper;
using eNatureBeauty.Model.Requests;
using eNatureBeauty.WebAPI.Database;
using System.Collections.Generic;
using System.Linq;
using Wishlist = eNatureBeauty.Model.Wishlists;

namespace eNatureBeauty.WebAPI.Services
{
    public class WishlistsService : IWishlistsService
    {
        private readonly natureBeautyContext _context;
        private readonly IMapper _mapper;
        public WishlistsService(natureBeautyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Delete(int id)
        {
            var entity = _context.Wishlists.Find(id);
            _context.Wishlists.Remove(entity);
            _context.SaveChanges();
        }

        public List<Wishlist> Get(WishlistsSearchRequest request)
        {
            var query = _context.Set<Database.Wishlists>().AsQueryable();
            if (request?.ProductId.HasValue == true)
            {
                query = query.Where(x => x.ProductId == request.ProductId);
            }
            if (request?.UserId.HasValue == true)
            {
                query = query.Where(x => x.UserId == request.UserId);
            }
            var list = query.ToList();

            return _mapper.Map<List<Model.Wishlists>>(list);
        }

        public Model.Wishlists GetById(int id)
        {
            var entity = _context.Wishlists.Find(id);

            return _mapper.Map<Model.Wishlists>(entity);
        }
        public void Insert(WishlistsUpsertRequest request)
        {
            Database.Wishlists entity = _mapper.Map<Database.Wishlists>(request);
            _context.Wishlists.Add(entity);
            _context.SaveChanges();

        }
        public void Update(int id, WishlistsUpsertRequest request)
        {
            var entity = _context.Wishlists.Find(id);
            _context.Wishlists.Attach(entity);
            _context.Wishlists.Update(entity);
            _mapper.Map(request, entity);
            _context.SaveChanges();
        }
    }
}