using System;
using System.Collections.Generic;

#nullable disable

namespace BDS.Model
{
    public partial class Ward
    {
        public Ward()
        {
            Projects = new HashSet<Project>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? DistrictId { get; set; }

        public virtual District District { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
}
