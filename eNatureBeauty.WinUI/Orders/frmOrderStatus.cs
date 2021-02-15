using eNatureBeauty.Model.Enums;
using eNatureBeauty.Model.Requests.Orders;
using eNatureBeauty.Model.Requests.Outputs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eNatureBeauty.WinUI.Orders
{
    public partial class frmOrderStatus : Form
    {
        private readonly Model.Orders _orders;
        private readonly APIService _service = new APIService("products");
        private readonly APIService _outputsService = new APIService("outputs");
        private readonly APIService _ordersService = new APIService("orders");
        private readonly APIService _outputsProductsService = new APIService("outputProducts");
        private readonly APIService _inputsProductsService = new APIService("inputProducts");
        private readonly APIService _inputsService = new APIService("inputs");

        public frmOrderStatus(Model.Orders order = null)
        {
            _orders = order;
            InitializeComponent();
        }

        private async void btnWaiting_Click(object sender, EventArgs e)
        {
            try
            {
                OrdersUpsertRequest request = new OrdersUpsertRequest
                {
                    Date = _orders.Date,
                    OrderNumber = _orders.OrderNumber,
                    Cancel = _orders.Cancel,
                    Status = OrderStatusTypes.Waiting.ToString(),
                    UserId = _orders.UserId,
                    Id = _orders.Id
                };
                await _ordersService.Update<Model.Orders>(_orders.Id, request);
                MessageBox.Show("Edited in Waiting Status", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtStatus.Text = OrderStatusTypes.Waiting.ToString();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnFinished_Click(object sender, EventArgs e)
        {
            try
            {
                OrdersUpsertRequest request = new OrdersUpsertRequest
                {
                    Date = _orders.Date,
                    OrderNumber = _orders.OrderNumber,
                    Cancel = _orders.Cancel,
                    Status = OrderStatusTypes.Finished.ToString(),
                    UserId = _orders.UserId,
                    Id = _orders.Id
                };
                await _ordersService.Update<Model.Orders>(_orders.Id, request);
                txtStatus.Text = OrderStatusTypes.Finished.ToString();
                MessageBox.Show("Edited in Finished Status", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                OutputsSearchRequest outputsSearch = new OutputsSearchRequest
                {
                    OrderId = _orders.Id
                };
                var output = await _outputsService.Get<List<Model.Outputs>>(outputsSearch);
                
                OutputsUpsertRequest outputsUpsert = new OutputsUpsertRequest
                {
                    Date = output.FirstOrDefault().Date,
                    Finished = true,
                    ReceiveNumber = output.FirstOrDefault().ReceiveNumber,
                    UserId = output.FirstOrDefault().UserId,
                    ValueWithoutPdv = output.FirstOrDefault().ValueWithoutPdv,
                    ValueWithPdv = output.FirstOrDefault().ValueWithPdv,
                    Id = output.FirstOrDefault().Id,
                    OrderId = _orders.Id
                };
                await _outputsService.Update<Model.Outputs>(output.FirstOrDefault().Id, outputsUpsert);
                this.Close();
            }
            catch
            {
                MessageBox.Show("Proccessing for now...", "Waiting...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void frmOrderStatus_Load(object sender, EventArgs e)
        {
            txtOrderNum.Text = _orders.OrderNumber;
            txtStatus.Text = _orders.Status;
        }
    }
}
