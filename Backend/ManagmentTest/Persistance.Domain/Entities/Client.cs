using Persistance.Domain.BaseProperties;

namespace Persistance.Domain.Entities
{
    public class Client : Identification, IAuditable, IDeleteFlag
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public ICollection<ClientAddress> ClientAddresses { get; set; }
        public ICollection<ClientNumber> ClientNumbers { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
