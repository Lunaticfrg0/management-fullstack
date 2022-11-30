namespace Persistance.Domain.BaseProperties
{
    internal interface IAuditable
    {
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
    }
}
