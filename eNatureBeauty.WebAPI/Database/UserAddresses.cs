using System;
using System.Collections.Generic;

namespace eNatureBeauty.WebAPI.Database
{
    public partial class UserAddresses
    {
        public UserAddresses()
        {
            Users = new HashSet<Users>();
        }

        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string AddressName { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}
