using System;
using System.Collections.Generic;

#nullable disable

namespace BDS.Model
{
    public partial class District
    {
        public District()
        {
            Wards = new HashSet<Ward>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? ProvinceId { get; set; }

        public virtual Province Province { get; set; }
        public virtual ICollection<Ward> Wards { get; set; }
    }
}
