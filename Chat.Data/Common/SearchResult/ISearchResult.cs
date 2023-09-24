namespace Chat.Data.Common.SearchResult
{
    public interface ISearchResult<TEntity>
    {
        int Page { get; set; }
        int PageSize { get; set; }
        IEnumerable<TEntity> Rows { get; set; }
        int TotalPages { get; }
        int TotalRows { get; set; }
    }
}