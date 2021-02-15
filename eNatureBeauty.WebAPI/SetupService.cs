using eNatureBeauty.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eNatureBeauty.WebAPI
{
    public class SetupService
    {
        public static void Init(natureBeautyContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}