using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BDS.Areas.Admin.Models.FeedBack
{
    public class FeedBackUpdateRequest
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? Status { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int? Phone { get; set; }
        public string Email { get; set; }
        public string Reply { get; set; }
    }
}
