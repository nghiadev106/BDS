using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BDS.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? Status { get; set; }
    }
}
