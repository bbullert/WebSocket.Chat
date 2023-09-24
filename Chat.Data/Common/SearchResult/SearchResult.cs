namespace Chat.Data.Common.SearchResult
{
    public class SearchResult<TEntity> : ISearchResult<TEntity>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalRows { get; set; }
        public int TotalPages => (int)Math.Ceiling((float)TotalRows / PageSize);
        public IEnumerable<TEntity> Rows { get; set; } = Enumerable.Empty<TEntity>();
    }
}
