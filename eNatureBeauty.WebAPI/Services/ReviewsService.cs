using AutoMapper;
using eNatureBeauty.Model.Requests;
using eNatureBeauty.WebAPI.Database;
using System.Collections.Generic;
using System.Linq;
using Reviews = eNatureBeauty.Model.Reviews.Reviews;

namespace eNatureBeauty.WebAPI.Services
{
    public class ReviewsService : IReviewsService
    {
        private readonly natureBeautyContext _context;
        private readonly IMapper _mapper;
        public ReviewsService(natureBeautyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Delete(int id)
        {
            var entity = _context.Reviews.Find(id);
            _context.Reviews.Remove(entity);
            _context.SaveChanges();
        }

        public List<Reviews> Get(ReviewsSearchRequest request = null)
        {
            var query = _context.Set<Database.Reviews>().AsQueryable();
            if (request?.ProductId.HasValue == true)
            {
                query = query.Where(x => x.ProductId == request.ProductId);
            }
            if (request?.UserId.HasValue == true)
            {
                query = query.Where(x => x.UserId == request.UserId);
            }
            var list = query.ToList();

            return _mapper.Map<List<Reviews>>(list);
        }

        public Reviews GetById(int id)
        {
            var entity = _context.Reviews.Find(id);

            return _mapper.Map<Reviews>(entity);
        }
        public void Insert(ReviewsUpsertRequest request)
        {
            Database.Reviews entity = _mapper.Map<Database.Reviews>(request);
            _context.Reviews.Add(entity);
            _context.SaveChanges();

        }
        public void Update(int id, ReviewsUpsertRequest request)
        {
            var entity = _context.Reviews.Find(id);
            _context.Reviews.Attach(entity);
            _context.Reviews.Update(entity);
            _mapper.Map(request, entity);
            _context.SaveChanges();
        }
    }
}
