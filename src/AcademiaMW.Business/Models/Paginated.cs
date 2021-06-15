using System.Collections.Generic;

namespace AcademiaMW.Business.Models
{
    public class Paginated<T>
    {
        public IEnumerable<T> Data { get; set; }
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }

        public bool HasPreviousPage { get; set; }

        public bool HasNextPage { get; set; }
    }
}
