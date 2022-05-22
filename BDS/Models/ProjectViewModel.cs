using BDS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BDS.Models
{
    public class ProjectViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string Detail { get; set; }
        public bool? IsNew { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? EditDate { get; set; }
        public string Url { get; set; }
        public int? DisplayOrder { get; set; }
        public int? Status { get; set; }
        public bool? IsHot { get; set; }
        public string Price { get; set; }
        public string Acreage { get; set; }
        public int? WardId { get; set; }
        public int? PriceTypeId { get; set; }
        public int? DirectionId { get; set; }
        public int? ProvinceId { get; set; }
        public int? DistrictId { get; set; }
        public int? Phone { get; set; }
        public string WardName { get; set; }
        public string DistrictName { get; set; }
        public string ProvinceName { get; set; }
        public string PriceTypeName { get; set; }
        public string DirectionName { get; set; }
        public string AddressDetail { get; set; }
        public List<ProjectImage> Images { get; set; }
    }
}
