using System.Collections.Generic;

namespace AcademiaMW.Core.Domain
{
    public class Pagination
    {
        public int PageSize { get; set; }
        public string Search { get; set; }
        public int PageIndex { get; set; }
    }
}
