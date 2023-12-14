using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace Infrastructure.Helpers.PaginationHelpers
{
    public static class PagingExtentions
    {
        public static IQueryable<T> ToPaging<T>(this IQueryable<T> dataModels, PageQuery pageQuery)
        {
            return pageQuery.PageSize == 0
                ? dataModels
                : dataModels
                    .Skip((pageQuery.Page - 1) * pageQuery.PageSize)
                    .Take(pageQuery.PageSize);
        }

        public static IQueryable<T> Sort<T>(this IQueryable<T> query, PageQuery pageQuery)
        {
            if (!string.IsNullOrWhiteSpace(pageQuery.Sorts))
            {
                var orderbyInfo = pageQuery.Sorts.Split('~');
                var feildName = orderbyInfo[0];
                query = query.OrderBy(feildName + " " + orderbyInfo[1]);
            }

            return query;
        }

        public static IQueryable<T> ToFilters<T>(this IQueryable<T> query, PageQuery pageQuery)
        {
            if (pageQuery is null || string.IsNullOrEmpty(pageQuery.SearchInfo.FieldName))
                return query;

            var feildName = pageQuery.SearchInfo.FieldName;
            var feildValue = pageQuery.SearchInfo.FieldValue;
            var filterOperator = pageQuery.SearchInfo.Operator;

            if (filterOperator.ToLower() == "like")
                query = query.Where($@"{feildName}.Contains(""{feildValue}"")");
            else
                query = query.Where($@"{feildName} {filterOperator} ""{feildValue}""");

            return query;
        }
    }
}
