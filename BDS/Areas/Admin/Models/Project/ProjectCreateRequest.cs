using BDS.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BDS.Areas.Admin.Models.Project
{
    public class ProjectCreateRequest
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Detail { get; set; }
        public bool? IsNew { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? EditDate { get; set; }
        public int? DisplayOrder { get; set; }
        public bool? IsHot { get; set; }
        public string Price { get; set; }
        public string Acreage { get; set; }

        [Required(ErrorMessage = "Bạn phải chọn địa chỉ")]
        public int? WardId { get; set; }
        public int? ProvinceId { get; set; }
        public int? DistrictId { get; set; }
        public int? PriceTypeId { get; set; }
        public int? DirectionId { get; set; }
        public int? Phone { get; set; }
        public string AddressDetail { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập tên sản phẩm")]
        [StringLength(500, ErrorMessage = "Tên sản phẩm không quá 500 ký tự")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Bạn phải chọn danh mục")]
        public int? CategoryId { get; set; }

        [StringLength(500, ErrorMessage = "Mô tả sản phẩm không quá 500 ký tự")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập URL")]
        public string Url { get; set; }

        public int? Status { get; set; }
        public bool IsNewInput
        {
            get => this.IsNew.GetValueOrDefault();
            set { this.IsNew = value; }
        }
        public bool IsHotInput
        {
            get => this.IsHot.GetValueOrDefault();
            set { this.IsHot = value; }
        }
        public IFormFile File { get; set; }
        public List<IFormFile> Files { get; set; }
        public List<ProjectImage> Images { get; set; }
    }
}
