using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eNatureBeauty.Model.Requests.Inputs
{
    public class InputsUpsertRequest //same here
    {
        public int Id { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime Date { get; set; }
        public decimal InvoiceAmount { get; set; }
        public decimal InvoiceAmountWithPDV { get; set; }

        public decimal Pdv { get; set; }
        public string Note { get; set; }
        public int StorageId { get; set; }
        public int UserId { get; set; }
    }
}
