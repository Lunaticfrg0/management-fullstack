namespace Helpers.GlobalEntities
{
    public class PaginationRequest
    {
        public ushort PageSize { get; set; }
        public ushort CurrentPage { get; set; }
        public string? SearchTerm { get; set; }
    }
}
