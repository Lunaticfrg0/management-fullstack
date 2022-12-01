namespace Business.Mappers.Dto
{
    public class ClientDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public IEnumerable<ClientAddressDto>? ClientAddresses { get; set; }
        public IEnumerable<ClientNumberDto>? ClientNumbers { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
