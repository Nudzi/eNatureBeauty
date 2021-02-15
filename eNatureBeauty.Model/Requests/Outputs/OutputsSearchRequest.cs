using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eNatureBeauty.Model.Requests.Outputs
{
    public class OutputsSearchRequest //same here
    {
        public int? OrderId { get; set; }
        public string ReceiveNumber { get; set; }
    }
}
