using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BDS.Areas.Admin.Models.Authen
{
    public class RegisterRequest
    {
        [EmailAddress(ErrorMessage = "Email không đúng định dạng")]
        [Required(ErrorMessage = "Bạn phải nhập email")]
        [StringLength(256, ErrorMessage = "Email không quá 256 ký tự")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập username")]
        [StringLength(256, ErrorMessage = "username không quá 256 ký tự")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập mật khẩu")]
        [StringLength(50, ErrorMessage = "Mật khẩu không quá 50 ký tự")]
        public string Password { get; set; }
        public string PhoneNumber { get; set; }

        [Compare("Password", ErrorMessage = "Mật khẩu xác nhận không chính xác")]
        [Required(ErrorMessage = "Bạn phải nhập mật khẩu xác nhận")]
        [StringLength(50, ErrorMessage = "Mật khẩu xác nhận không quá 50 ký tự")]
        public string ConfirmPassword { get; set; }
    }
}
