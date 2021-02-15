using System;
using System.Collections.Generic;

namespace eNatureBeauty.Model
{
    public class Inputs
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
