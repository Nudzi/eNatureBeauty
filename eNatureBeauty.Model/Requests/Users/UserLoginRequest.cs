using System;
using System.Collections.Generic;
using System.Text;

namespace eNatureBeauty.Model.Requests.Users
{
    public class UserLoginRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
