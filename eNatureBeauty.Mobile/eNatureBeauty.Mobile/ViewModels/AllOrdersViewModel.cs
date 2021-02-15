using eNatureBeauty.Mobile.Services;
using eNatureBeauty.Model;
using eNatureBeauty.Model.Enums;
using eNatureBeauty.Model.Requests.Orders;
using eNatureBeauty.Model.Requests.Outputs;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eNatureBeauty.Mobile.ViewModels
{
    public class AllOrdersViewModel : BaseViewModel
    {
        private readonly APIService _ordersService = new APIService("orders");
        private readonly APIService _outputsService = new APIService("outputs");

        public AllOrdersViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }
        public Users User { get; set; }
        public List<Orders> ordersList { get; set; } = new List<Orders>();
        public ObservableCollection<Outputs> outputs { get; set; } = new ObservableCollection<Outputs>();
        public ObservableCollection<Outputs> outputsOld { get; set; } = new ObservableCollection<Outputs>();
        public ObservableCollection<Outputs> outputsCreated { get; set; } = new ObservableCollection<Outputs>();
        public ObservableCollection<Outputs> outputsWaiting { get; set; } = new ObservableCollection<Outputs>();

        public ICommand InitCommand { get; set; }
        public async Task CancelOrder(int outputId)
        {
            try
            {
                var outputF = await _outputsService.GetById<Model.Outputs>(outputId);
                var order = await _ordersService.GetById<Model.Orders>(outputF.OrderId);
                OrdersUpsertRequest request = new OrdersUpsertRequest
                {
                    Cancel = !order.Cancel,
                    Date = order.Date,
                    OrderNumber = order.OrderNumber,
                    Status = order.Status,
                    UserId = order.UserId,
                    Id = order.Id
                };
                await _ordersService.Update<Model.Orders>(order.Id, request);
                await Application.Current.MainPage.DisplayAlert("Success", "Order is canceled!", "OK");
            }
            catch
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Cannot cancel now!", "OK");
            }

        }
        public async Task Init()
        {
            outputs.Clear();
            outputsOld.Clear();
            outputsCreated.Clear();
            outputsWaiting.Clear();
            OrdersSearchRequest request = new OrdersSearchRequest
            {
                UserId = User.Id
            };
            ordersList = await _ordersService.Get<List<Model.Orders>>(request);

            foreach (var item in ordersList)
            {
                OutputsSearchRequest outputsSearchRequest = new OutputsSearchRequest
                {
                    OrderId = item.Id
                };
                var outputsFinded = (await _outputsService.Get<List<Model.Outputs>>(outputsSearchRequest));
                if ((bool)!item.Cancel)
                {
                    foreach (var tmp in outputsFinded)
                    {
                        outputs.Add(tmp);
                    }
                }
                if (item.Status == OrderStatusTypes.Finished.ToString())
                {
                    foreach (var tmp in outputsFinded)
                    {
                        outputsOld.Add(tmp);
                    }
                }
                if (item.Status == OrderStatusTypes.Waiting.ToString())
                {
                    foreach (var tmp in outputsFinded)
                    {
                        outputsWaiting.Add(tmp);
                    }
                }
                if (item.Status == OrderStatusTypes.Created.ToString())
                {
                    foreach (var tmp in outputsFinded)
                    {
                        outputsCreated.Add(tmp);
                    }
                }
            }
        }
    }
}
