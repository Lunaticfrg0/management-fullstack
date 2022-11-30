using Persistance.Domain.BaseProperties;

namespace Persistance.Domain.Entities
{
    public class ClientAddress : Identification, IDeleteFlag, IAuditable
    {
        public string FirstLine { get; set; }
        public string SecondLine { get; set; }
        public string ZipCode { get; set; }
        public string AdditionalDetails { get; set; }
        public Client Client { get; set; }
        public Guid ClientId { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
