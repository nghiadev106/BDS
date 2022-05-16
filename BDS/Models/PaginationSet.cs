using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BDS.Models
{
    public class PaginationSet<T>
    {
        public int Page { set; get; }
        public string Sort { set; get; }      
        public string Keyword { set; get; }
        public int PageSize { set; get; }

        public int Count
        {
            get
            {
                return (Items != null) ? Items.Count() : 0;
            }
        }

        public int TotalPages { set; get; }
        public int TotalCount { set; get; }
        public int MaxPage { set; get; }
        public IEnumerable<T> Items { set; get; }
    }
}
