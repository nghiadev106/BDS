﻿using System;
using System.Collections.Generic;

#nullable disable

namespace BDS.Model
{
    public partial class PriceType
    {
        public PriceType()
        {
            Projects = new HashSet<Project>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}
