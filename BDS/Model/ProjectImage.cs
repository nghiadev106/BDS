using System;
using System.Collections.Generic;

#nullable disable

namespace BDS.Model
{
    public partial class ProjectImage
    {
        public int Id { get; set; }
        public int? ProjectId { get; set; }
        public string Path { get; set; }

        public virtual Project Project { get; set; }
    }
}
