namespace Chat.Data.Common.SearchCriteria
{
    public interface ISearchCriteria
    {
        int Page { get; set; }
        int PageSize { get; set; }
        string? SortBy { get; set; }
    }
}