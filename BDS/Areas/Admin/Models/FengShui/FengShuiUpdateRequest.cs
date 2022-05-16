using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace BDS.Areas.Admin.Models.FengShui
{
    public class FengShuiUpdateRequest
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập tên bài viết")]
        [StringLength(500, ErrorMessage = "tên bài viết không quá 500 ký tự")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Bạn phải chọn danh mục")]
        public int? CategoryId { get; set; }
        public string Image { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập mô tả bài viết")]
        [StringLength(500, ErrorMessage = "mô tả bài viết không quá 500 ký tự")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập chi tiết bài viết")]
        public string Detail { get; set; }

        public bool? IsNew { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? EditDate { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập URL")]
        public string Url { get; set; }
        public int? DisplayOrder { get; set; }

        [Required(ErrorMessage = "Bạn phải chọn trạng thái")]
        public int? Status { get; set; }
        public bool IsNewInput
        {
            get => this.IsNew.GetValueOrDefault();
            set { this.IsNew = value; }
        }
        public IFormFile FileUpload { get; set; }
    }
}
