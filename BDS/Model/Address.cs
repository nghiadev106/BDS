using System;
using System.Collections.Generic;

#nullable disable

namespace BDS.Model
{
    public partial class Address
    {
        public Address()
        {
            Projects = new HashSet<Project>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}
