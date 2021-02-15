using System;
using System.Collections.Generic;

namespace eNatureBeauty.WebAPI.Database
{
    public partial class Outputs
    {
        public Outputs()
        {
            OutputProducts = new HashSet<OutputProducts>();
        }

        public int Id { get; set; }
        public string ReceiveNumber { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public bool Finished { get; set; }
        public decimal ValueWithoutPdv { get; set; }
        public decimal ValueWithPdv { get; set; }
        public int? OrderId { get; set; }

        public virtual Orders Order { get; set; }
        public virtual Users User { get; set; }
        public virtual ICollection<OutputProducts> OutputProducts { get; set; }
    }
}
