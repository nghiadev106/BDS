using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BDS.Models
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "Bạn phải nhập username")]
        [StringLength(256, ErrorMessage = "username không quá 256 ký tự")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập mật khẩu")]
        [StringLength(50, ErrorMessage = "Mật khẩu không quá 50 ký tự")]
        public string Password { get; set; }

    }
}
