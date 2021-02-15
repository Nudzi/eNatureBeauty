using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eNatureBeauty.Model.Requests.Outputs
{
    public class OutputsUpsertRequest //same here
    {
        public int Id { get; set; }
        public string ReceiveNumber { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public bool Finished { get; set; }
        public decimal ValueWithoutPdv { get; set; }
        public decimal ValueWithPdv { get; set; }
        public int? OrderId { get; set; }
    }
}
