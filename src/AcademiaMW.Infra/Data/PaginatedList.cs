using AcademiaMW.Business.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademiaMW.Infra.Data
{
    public class PaginatedList<T> : Paginated<T>
    {
        public PaginatedList(List<T> data, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            Data = data;
            HasPreviousPage = PageIndex > 1;
            HasNextPage = PageIndex < TotalPages;
        }

        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            pageIndex = pageIndex == 0 ? 1 : pageIndex;
            pageSize = pageSize == 0 ? 10 : pageSize;

            var count = await source.CountAsync();
            var data = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();

            return new PaginatedList<T>(data, count, pageIndex, pageSize);
        }
        
    }
}
