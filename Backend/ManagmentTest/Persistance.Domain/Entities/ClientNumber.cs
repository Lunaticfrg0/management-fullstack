using Persistance.Domain.BaseProperties;

namespace Persistance.Domain.Entities
{
    public class ClientNumber : Identification
    {
        public string Number { get; set; }
        public Client Client { get; set; }
        public Guid ClientId { get; set; }
    }
}
