﻿using System;
using System.Collections.Generic;

#nullable disable

namespace BDS.Model
{
    public partial class Project
    {
        public Project()
        {
            ProjectImages = new HashSet<ProjectImage>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? CategoryId { get; set; }
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
        public decimal? Price { get; set; }
        public string Acreage { get; set; }
        public int? AddressId { get; set; }
        public string AddressDetail { get; set; }

        public virtual Address Address { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<ProjectImage> ProjectImages { get; set; }
    }
}
