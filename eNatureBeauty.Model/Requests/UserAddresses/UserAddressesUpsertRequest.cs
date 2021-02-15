using System;
using System.Collections.Generic;
using System.Text;

namespace eNatureBeauty.Model.Requests.UserAddresses
{
    public class UserAddressesUpsertRequest
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string AddressName { get; set; }
    }
}
