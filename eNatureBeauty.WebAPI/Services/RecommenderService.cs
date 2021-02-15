using AutoMapper;
using eNatureBeauty.WebAPI.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eNatureBeauty.WebAPI.Services
{
    public class RecommenderService : IRecommender
    {
        Dictionary<int, List<Model.Reviews.Reviews>> products = new Dictionary<int, List<Model.Reviews.Reviews>>();

        private readonly natureBeautyContext _context;
        private readonly IMapper _mapper;
        public RecommenderService(natureBeautyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<Model.Products> GetAlikeProducts(int productId) {

            LoadProducts(productId);


            List<Model.Reviews.Reviews> reviewsOfObservableProduct = new List<Model.Reviews.Reviews>();
            List<Database.Reviews> reviewsFromDatabase = _context.Reviews.Where(x => x.ProductId == productId).OrderBy(y => y.UserId).ToList();
            _mapper.Map(reviewsFromDatabase, reviewsOfObservableProduct);



            List<Model.Reviews.Reviews> stackOfReviews1 = new List<Model.Reviews.Reviews>();
            List<Model.Reviews.Reviews> stackOfReviews2 = new List<Model.Reviews.Reviews>();
            List<Model.Products> recommendedProducts = new List<Model.Products>();

            foreach (var item in products)
            {
                foreach (Model.Reviews.Reviews o in reviewsOfObservableProduct)
                {
                    if (item.Value.Where(x => x.UserId == o.UserId).Count() > 0)
                    {
                        stackOfReviews1.Add(o);
                        stackOfReviews2.Add(item.Value.Where(x => x.UserId == o.UserId).First());
                    }
                }

                double alike = 0;
                alike = GetSimilarity(stackOfReviews1, stackOfReviews2);


                if (alike > 0.95)
                {
                    Database.Products element1 = _context.Products.Include(y => y.ProductType).Include(y => y.OutputProducts).Where(x => x.Id == item.Key).FirstOrDefault();
                    Model.Products element2 = new Model.Products();

                    element2.Id = element1.Id;
                    element2.Image = element1.Image;
                    element2.ImageThumb = element1.ImageThumb;
                    element2.Name = element1.Name;
                    element2.Code = element1.Code;
                    element2.Description = element1.Description;
                    element2.Price = element1.Price;
                    element2.ProductTypeId = element1.ProductTypeId;
                    element2.Status = element1.Status;



                    recommendedProducts.Add(element2);

                }

                stackOfReviews1.Clear();
                stackOfReviews2.Clear();
            }

            return recommendedProducts;
        }

        private double GetSimilarity(List<Model.Reviews.Reviews> jointReview1, List<Model.Reviews.Reviews> jointReview2)
        {
            if (jointReview1.Count != jointReview2.Count)
                return 0;

            double numerator = 0, denumerator1 = 0, denumerator2 = 0;

            for (int i = 0; i < jointReview1.Count; i++)
            {
                numerator += jointReview1[i].Review * jointReview2[i].Review;
                denumerator1 += jointReview1[i].Review * jointReview1[i].Review;
                denumerator2 += jointReview2[i].Review * jointReview2[i].Review;

            }
            denumerator1 = Math.Sqrt(denumerator1);
            denumerator2 = Math.Sqrt(denumerator2);
            double denumerator = denumerator1 * denumerator2;
            if (denumerator == 0)
                return 0;
            return numerator / denumerator;
        }

        private void LoadProducts(int productId)
        {
            List<Database.Products> activeProizvodi = _context.Products.Include(y => y.ProductType).Include(z => z.OutputProducts).Where(x => x.Id != productId).ToList();

            Database.Products observedProduct = _context.Products.Where(x => x.Id == productId).SingleOrDefault();

            List<Model.Products> newList = new List<Model.Products>();
            _mapper.Map(activeProizvodi, newList);



            List<Model.Products> finalList = new List<Model.Products>();
            foreach (var item in newList)
            {
                if (item.ProductTypeId == observedProduct.ProductTypeId)
                {
                    finalList.Add(item);
                }
            }


            foreach (Model.Products a in finalList)
            {
                List<Database.Reviews> newListReviews = _context.Reviews.Where(x => x.ProductId == a.Id).ToList();
                List<Model.Reviews.Reviews> reviews = new List<Model.Reviews.Reviews>();
                foreach (var item2 in newListReviews)
                {

                    Model.Reviews.Reviews newReview = new Model.Reviews.Reviews();
                    newReview.ProductId = item2.ProductId;
                    newReview.Review = item2.Review;
                    newReview.UserId = item2.UserId;
                    newReview.Description = item2.Description;
                    newReview.Id = item2.Id;


                    reviews.Add(newReview);
                }

                if (reviews.Count > 0)
                    products.Add(a.Id, reviews);

            }
        }
    }
}
