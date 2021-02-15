using System.Collections.Generic;
using eNatureBeauty.Model.Requests;
using Reviews = eNatureBeauty.Model.Reviews.Reviews;

namespace eNatureBeauty.WebAPI.Services
{
    public interface IReviewsService
    {
        List<Reviews> Get(ReviewsSearchRequest request);
        Reviews GetById(int id);
        void Insert(ReviewsUpsertRequest request);
        void Update(int id, ReviewsUpsertRequest request);
        void Delete(int id);
    }
}
