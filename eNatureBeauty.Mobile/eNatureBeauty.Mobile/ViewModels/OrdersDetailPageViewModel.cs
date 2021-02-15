using eNatureBeauty.Mobile.Services;
using eNatureBeauty.Model;
using eNatureBeauty.Model.Enums;
using eNatureBeauty.Model.Requests.Orders;
using eNatureBeauty.Model.Requests.OutputProducts;
using eNatureBeauty.Model.Requests.Outputs;
using eNatureBeauty.Model.Requests.UserAddresses;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eNatureBeauty.Mobile.ViewModels
{
    public class OrdersDetailPageViewModel : BaseViewModel
    {
        private readonly APIService _userAddresssesService = new APIService("userAddresses");
        private readonly APIService _usersService = new APIService("users");
        private readonly APIService _ordersService = new APIService("orders");
        private readonly APIService _outputsService = new APIService("outputs");
        private readonly APIService _outputProductsService = new APIService("outputProducts");
        public ObservableCollection<ProductsDetailViewModel> ProductsList { get; set; } = new ObservableCollection<ProductsDetailViewModel>();
        public OrdersDetailPageViewModel()
        {
            InitCommand = new Command(async () => await Init());
            SaveOrderCommand = new Command(async () => await SaveOrder());
            StateLenghtCommand = new Command(async () => await StateLenght());
            CityLenghtCommand = new Command(async () => await CityLenght());
            AddressLenghtCommand = new Command(async () => await AddressLenght());
        }
        public Users User { get; set; }

        public UserAddresses UserAddress { get; set; } = new UserAddresses();

        decimal _total = 0;
        string _country = string.Empty;
        string _city = string.Empty;

        decimal _discount = 0;
        public decimal Discount
        {
            get { return _discount; }
            set { SetProperty(ref _discount, value); }
        }

        decimal _totalNoPDV = 0;
        public decimal TotalNoPDV
        {
            get { return _totalNoPDV; }
            set { SetProperty(ref _totalNoPDV, value); }
        }

        string _addressName = string.Empty;
        public decimal Total
        {
            get { return _total; }
            set { SetProperty(ref _total, value); }
        }
        public string Country
        {
            get { return _country; }
            set { SetProperty(ref _country, value); }
        }
        public string City
        {
            get { return _city; }
            set { SetProperty(ref _city, value); }
        }
        public string AddressName
        {
            get { return _addressName; }
            set { SetProperty(ref _addressName, value); }
        }
        private ICommand InitCommand { get; set; }
        public ICommand SaveOrderCommand { get; set; }
        public ICommand CancelOrderCommand { get; set; }
        public ICommand StateLenghtCommand { get; set; }
        public ICommand CityLenghtCommand { get; set; }
        public ICommand AddressLenghtCommand { get; set; }
        
        public async Task StateLenght()
        {
            if(Country.Length == 0)
            {
                var user = await _usersService.GetById<Model.Users>(User.Id);
                UserAddress = await _userAddresssesService.GetById<Model.UserAddresses>(user.UserAddressId);

                Country = UserAddress.Country;
            }
        }
        public async Task CityLenght()
        {
            if (City.Length == 0)
            {
                var user = await _usersService.GetById<Model.Users>(User.Id);
                UserAddress = await _userAddresssesService.GetById<Model.UserAddresses>(user.UserAddressId);

                City = UserAddress.City;
            }
        }
        public async Task AddressLenght()
        {
            if (AddressName.Length == 0)
            {
                var user = await _usersService.GetById<Model.Users>(User.Id);
                UserAddress = await _userAddresssesService.GetById<Model.UserAddresses>(user.UserAddressId);

                AddressName = UserAddress.AddressName;
            }
        }
        public async Task Init()
        {
            var user = await _usersService.GetById<Model.Users>(User.Id);
            UserAddress = await _userAddresssesService.GetById<Model.UserAddresses>(user.UserAddressId);

            Country = UserAddress.Country;
            City = UserAddress.City;
            AddressName = UserAddress.AddressName;

            ProductsList.Clear();
            foreach (var item in CartService.Cart)
            {
                ProductsList.Add(item.Value);
            }
            foreach (var item in ProductsList)
            {
                Total += item.Product.Price * item.Quantity;
                Discount += item.Quantity;
            }
            if (Discount > 100)
                Discount = 50;
            if (Discount < 20)
                Discount = 0;
            else Discount /= 2;

            TotalNoPDV = Total;
            Total -= (Discount / 100 * Total);
            Total += 5;
        }
        public async Task SaveOrder()
        {
            await AddressLenght();
            await CityLenght();
            await StateLenght();

            var user = await _usersService.GetById<Model.Users>(User.Id);
            UserAddress = await _userAddresssesService.GetById<Model.UserAddresses>(user.UserAddressId);

            UserAddressesUpsertRequest userAddressesUpserRequest = new UserAddressesUpsertRequest
            {
                AddressName = AddressName,
                City = City,
                Country = Country,
                Id = UserAddress.Id
            };

            await _userAddresssesService.Update<Model.UserAddresses>(UserAddress.Id, userAddressesUpserRequest);


            OrdersUpsertRequest ordersUpsertRequest = new OrdersUpsertRequest
            {
                Date = DateTime.Now,
                Cancel = false,
                OrderNumber = Helper.GenerateString(19),
                Status = OrderStatusTypes.Created.ToString(),
                UserId = User.Id
            };
            try
            {
                var order = await _ordersService.Insert<Model.Orders>(ordersUpsertRequest);
                OutputsUpsertRequest outputsUpsertRequest = new OutputsUpsertRequest
                {
                    Date = DateTime.Now,
                    UserId = User.Id,
                    Finished = false,
                    OrderId = order.Id,
                    ReceiveNumber = Helper.GenerateString(19),
                    ValueWithoutPdv = TotalNoPDV,
                    ValueWithPdv = Total
                };
                var outputs = await _outputsService.Insert<Model.Outputs>(outputsUpsertRequest);

                foreach (var item in ProductsList)
                {
                    OutputProductsUpsertRequest request = new OutputProductsUpsertRequest
                    {
                        ProductId = item.Product.Id,
                        Price = item.Product.Price,
                        OutputId = outputs.Id,
                        Quantity = (int)item.Quantity,
                        Discount = (item.Quantity / 2)
                    };
                    if (request.Quantity > 100)
                        request.Discount = 50;
                    if (request.Quantity < 20)
                        request.Discount = 0;
                    await _outputProductsService.Insert<Model.OutputProducts>(request);
                }
                ProductsList.Clear();
                CartService.Cart.Clear();
                await Application.Current.MainPage.DisplayAlert("Success", "Order is sent!", "OK");
            }
            catch
            {
                await Application.Current.MainPage.DisplayAlert("Error", "", "OK");
            }
        }
    }
}
