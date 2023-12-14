namespace Infrastructure.Helpers.PaginationHelpers
{
    public class PageQuery
    {
        public PageQuery()
        {
            Page = 1;
            PageSize = 10;
            this.Sorts = string.Empty;
        }

        public string Sorts { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; }

        public SearchInfo SearchInfo { get; set; } = new();

        public static PageQuery Default => new PageQuery { Page = 1, PageSize = 100 };
    }
}

