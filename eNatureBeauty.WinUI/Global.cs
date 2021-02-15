using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eNatureBeauty.WinUI
{
    public class Global
    {
        public static Model.Users LoggedUser { get; set; }
        public static bool Admin { get; set; }
        public static bool Client { get; set; }
        public static bool User { get; set; }
        public static bool Employee { get; set; }
        public static bool shouldEditRoles { get; set; }
        public static bool shouldEditProduct { get; set; }

    }
}
