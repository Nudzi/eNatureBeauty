using System;
using System.Collections.Generic;

namespace eNatureBeauty.Model
{
    public class Outputs
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
