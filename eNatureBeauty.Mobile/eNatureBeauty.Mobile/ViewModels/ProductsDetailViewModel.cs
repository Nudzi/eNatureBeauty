using eNatureBeauty.Mobile.Services;
using eNatureBeauty.Model;
using eNatureBeauty.Model.Requests;
using eNatureBeauty.Model.Reviews;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eNatureBeauty.Mobile.ViewModels
{
    public class ProductsDetailViewModel : BaseViewModel
    {
        private readonly APIService _reviewsService = new APIService("reviews");
        private readonly APIService _wishlistsService = new APIService("wishlists");
        private readonly APIService _inputsService = new APIService("inputs");
        private readonly APIService _recommenderService = new APIService("recommender");
        private readonly APIService _inputProductsService = new APIService("inputProducts");
        private readonly string NO_CONTENT = "*NO_CONTENT*";
        public ObservableCollection<Model.Products> RecommenderList { get; set; } = new ObservableCollection<Products>();

        public ProductsDetailViewModel()
        {
            AddQuantityCommand = new Command(async() => await SetMaximum());
            OrderCommand = new Command(async () => await Order());
            AddReviewCommand = new Command(AddReview);
            InitCommand = new Command(async () => await Init());
            RecommenderCommand = new Command(async () => await Recommend());
        }
        public ObservableCollection<Reviews> ReviewsList { get; set; } = new ObservableCollection<Reviews>();
        public ObservableCollection<Reviews> ReviewsListUser { get; set; } = new ObservableCollection<Reviews>();

        public Products Product { get; set; }
        public Users User { get; set; }

        public bool isFirstTime = false;
        public bool recommendationsDoesNotExist = true;
        decimal _quantity = 0;
        public decimal Quantity
        {
            get { return _quantity; }
            set { SetProperty(ref _quantity, value); }
        }
        string _description = string.Empty;
        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }

        int _review = 0;
        public int Review
        {
            get { return _review; }
            set { SetProperty(ref _review, value); }
        }

        bool _isToggled = false;
        public bool IsToggled
        {
            get { return _isToggled; }
            set { SetProperty(ref _isToggled, value); }
        }
        bool _isAvailable = true;
        public bool IsAvailable
        {
            get { return _isAvailable; }
            set { SetProperty(ref _isAvailable, value); }
        }

        List<decimal> _average = new List<decimal>();
        public List<decimal> Average
        {
            get { return _average; }
            set { SetProperty(ref _average, value); }
        }
        public ICommand AddQuantityCommand { get; set; }
        public ICommand InitCommand { get; set; }
        public ICommand OrderCommand { get; set; }
        public ICommand AddReviewCommand { get; set; }
        public ICommand DeleteReviewCommand { get; set; }
        public ICommand RecommenderCommand { get; set; }


        public async Task Recommend()
        {
            IsBusy = false;
            RecommenderList.Clear();
            List<Model.Products> list = new List<Model.Products>();
            list = await _recommenderService.GetAlikeProducts<List<Model.Products>>(Product.Id);

            List<Model.Reviews.Reviews> reviewList = new List<Model.Reviews.Reviews>();
            reviewList = await _reviewsService.Get<List<Model.Reviews.Reviews>>(null);

            if (list.Count == 0)
                IsBusy = true;

            foreach (var item in list)
            {
                //    int total = 0;
                //    decimal sum = 0;

                //    foreach (var tmp in reviewList)
                //    {
                //        if (tmp.ProductId == item.Id)
                //        {
                //            total += tmp.Review;
                //            sum++;
                //        }
                //    }

                //    Average.Add(sum / total);

                RecommenderList.Add(item);

            }
        }
        public async Task SetMaximum()
        {
            try
            {
                Quantity += 1;
                int maximum = await Helper.numInStorage(Product.Id);
                if (Quantity > maximum)
                {
                    await Application.Current.MainPage.DisplayAlert("Important", "Product " + Product.Name + " is only available in Quantity " + maximum, "OK");
                    Quantity -= 1;
                    return;
                }
            }
            catch
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Error", "OK");
            }
        }
        public async Task Order()
        {
            if(Quantity == 0)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Cannot add 0 number of products!", "OK");
                return;
            }
            if (CartService.Cart.ContainsKey(Product.Id))
            {
                CartService.Cart.Remove(Product.Id);
                await Application.Current.MainPage.DisplayAlert("Success", "Product " + Product.Name + " removed from cart!", "OK");
                return;
            }
            CartService.Cart.Add(Product.Id, this);
            await Application.Current.MainPage.DisplayAlert("Success", "Product " + Product.Name + " added to cart!", "OK");
        }
        public async Task DeleteReview(int id)
        {
            try
            {
                await _reviewsService.Delete<Reviews>(id);
                await Application.Current.MainPage.DisplayAlert("Success", "Sucessfuly removed review", "OK");
                await Init();
            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Cannot be removed now!", "OK");
            }
        }
        private async void AddReview()
        {
                ReviewsUpsertRequest request = new ReviewsUpsertRequest
                {
                    Description = Description,
                    Review = Review,
                    ProductId = Product.Id,
                    UserId = User.Id
                };
            try
            {
                await _reviewsService.Insert<Reviews>(request);
                await Application.Current.MainPage.DisplayAlert("Success", "Sucessfuly added review","OK");
                Description = "";
                Review = 0;
                await Init();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }
        public async Task Init()
        {
            await Recommend();

            int maximum = await Helper.numInStorage(Product.Id);
            if(Quantity == 0)
                _isAvailable = false;

            WishlistsSearchRequest requestWish = new WishlistsSearchRequest
            {
                ProductId = Product.Id,
                UserId = User.Id
            };
            try
            {
                ICollection<Wishlists> wishlist = await _wishlistsService.Get<ICollection<Wishlists>>(requestWish);
                if (wishlist.Count == 0)
                    IsToggled = false;
                else
                {
                    isFirstTime = true;
                    IsToggled = true;
                }
            }
            catch (Exception ex)
            {
                IsToggled = false;
            }

            ReviewsSearchRequest requestAll = new ReviewsSearchRequest
            {
                ProductId = Product.Id
            };
            var listAll = await _reviewsService.Get<IEnumerable<Reviews>>(requestAll);
            ReviewsList.Clear();
            foreach (var item in listAll)
            {
                if (item.Description.Equals(""))
                {
                    item.Description = NO_CONTENT;
                }
                ReviewsList.Add(item);
            }

            ReviewsSearchRequest requestUser = new ReviewsSearchRequest
            {
                ProductId = Product.Id,
                UserId = User.Id
            };
            var listUser = await _reviewsService.Get<ICollection<Reviews>>(requestUser);
            ReviewsListUser.Clear();
            foreach (var item in listUser)
            {
                if (item.Description.Equals(""))
                {
                    item.Description = NO_CONTENT;
                }
                ReviewsListUser.Add(item);
            }
        }
        public async Task EditInWishlist(bool item)
        {
            if (!item) {
                WishlistsSearchRequest requestWish = new WishlistsSearchRequest
                {
                    ProductId = Product.Id,
                    UserId = User.Id
                };
                try
                {
                    IEnumerable<Wishlists> wishlist = await _wishlistsService.Get<IEnumerable<Wishlists>>(requestWish);
                    foreach (var tmp in wishlist)
                    {
                        await _wishlistsService.Delete<Wishlists>(tmp.Id);
                    }
                }
                catch (Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
                }
            }
            else
            {
                WishlistsUpsertRequest requestWish = new WishlistsUpsertRequest
                {
                    ProductId = Product.Id,
                    UserId = User.Id
                };
                try
                {
                    await _wishlistsService.Insert<Wishlists>(requestWish);
                }
                catch (Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
                }
            }
        }
    }
}
