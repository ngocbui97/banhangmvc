using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanHang.common
{
    [Serializable]
    public class UserLogin
    {
        
        public int UserId { get; set; }
        public String UserName { get; set; }
    }
}