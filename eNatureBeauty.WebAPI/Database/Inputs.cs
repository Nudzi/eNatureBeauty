using System;
using System.Collections.Generic;

namespace eNatureBeauty.WebAPI.Database
{
    public partial class Inputs
    {
        public Inputs()
        {
            InputProducts = new HashSet<InputProducts>();
        }

        public int Id { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime Date { get; set; }
        public decimal InvoiceAmount { get; set; }
        public decimal Pdv { get; set; }
        public string Note { get; set; }
        public int StorageId { get; set; }
        public int UserId { get; set; }
        public decimal? InvoiceAmountWithPdv { get; set; }

        public virtual Storages Storage { get; set; }
        public virtual Users User { get; set; }
        public virtual ICollection<InputProducts> InputProducts { get; set; }
    }
}
