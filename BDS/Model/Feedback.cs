using System;
using System.Collections.Generic;

#nullable disable

namespace BDS.Model
{
    public partial class Feedback
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? Status { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int? Phone { get; set; }
        public string Email { get; set; }
    }
}
