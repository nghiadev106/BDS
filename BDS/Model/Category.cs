using System;
using System.Collections.Generic;

#nullable disable

namespace BDS.Model
{
    public partial class Category
    {
        public Category()
        {
            Projects = new HashSet<Project>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public int? DisplayOrder { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool? ShowHome { get; set; }
        public int? Status { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}
