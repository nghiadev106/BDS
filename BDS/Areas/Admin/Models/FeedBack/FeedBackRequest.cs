using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BDS.Areas.Admin.Models.FeedBack
{
    public class FeedBackRequest
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập nội dung")]
        public string Message { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? Status { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập tên")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập địa chỉ")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập số điện thoại")]
        public int? Phone { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập email")]
        public string Email { get; set; }
    }
}
