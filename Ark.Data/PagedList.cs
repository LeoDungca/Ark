using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ark.Data
{
    public interface IPagedRecords<T>
    {
        int PageSize { get; set; }
        int PageNumber { get; set; }
        int TotalPages { get; set; }
        int TotalRecords { get; set; }
        IList<T> PageRecords { get; set; }
    }

    public class PagedRecords<T> : IPagedRecords<T>
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
        public IList<T> PageRecords { get; set; }

    }

    public static class PaginationHelpers
    {
        public static IPagedRecords<T> ToPagedRecords<T>(this IQueryable<T> query, int pageSize, int pageNumber)
        {
            var pagedRecs = new PagedRecords<T> { PageSize = pageSize, PageNumber = pageNumber };

            pagedRecs.TotalRecords = query.Count();
            pagedRecs.TotalPages = (int)Math.Ceiling(pagedRecs.TotalRecords / (double)pagedRecs.PageSize);
            pagedRecs.PageRecords = query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();


            return pagedRecs;
        }
    }
}
