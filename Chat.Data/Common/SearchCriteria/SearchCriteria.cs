namespace Chat.Data.Common.SearchCriteria
{
    public class SearchCriteria : ISearchCriteria
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = int.MaxValue;
        public string? SortBy { get; set; }
    }
}
