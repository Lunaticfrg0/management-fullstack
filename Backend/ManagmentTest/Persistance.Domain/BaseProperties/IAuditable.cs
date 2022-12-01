namespace Persistance.Domain.BaseProperties
{
    public interface IAuditable
    {
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
    }
}
