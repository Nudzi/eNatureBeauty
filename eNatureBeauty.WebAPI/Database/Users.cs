using System;
using System.Collections.Generic;

namespace eNatureBeauty.WebAPI.Database
{
    public partial class Users
    {
        public Users()
        {
            Inputs = new HashSet<Inputs>();
            Orders = new HashSet<Orders>();
            Outputs = new HashSet<Outputs>();
            Reviews = new HashSet<Reviews>();
            UsersUserTypes = new HashSet<UsersUserTypes>();
            Wishlists = new HashSet<Wishlists>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public bool? Status { get; set; }
        public int? UserAddressId { get; set; }

        public virtual UserAddresses UserAddress { get; set; }
        public virtual ICollection<Inputs> Inputs { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
        public virtual ICollection<Outputs> Outputs { get; set; }
        public virtual ICollection<Reviews> Reviews { get; set; }
        public virtual ICollection<UsersUserTypes> UsersUserTypes { get; set; }
        public virtual ICollection<Wishlists> Wishlists { get; set; }
    }
}
