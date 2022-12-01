namespace Helpers.GlobalEntities
{
    public class PaginationResult<T>
    {
        public List<T> List { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
    }
}
