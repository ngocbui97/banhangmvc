using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BanHang.Areas.admin.Models
{
    public class Login
    {
        [Required(ErrorMessage="Nhap UserName")]
        public String UserName { get; set; }
        [Required(ErrorMessage = "Nhap PassWord")]
        public String PassWord { get; set; }
        public bool RememberMe { get; set; }

    }
}