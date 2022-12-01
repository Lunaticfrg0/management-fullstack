namespace Business.Mappers.Dto
{
    public class ClientAddressDto
    {
        public Guid Id { get; set; }
        public string FirstLine { get; set; }
        public string SecondLine { get; set; }
        public string ZipCode { get; set; }
        public string AdditionalDetails { get; set; }
        public Guid ClientId { get; set; }
    }
}
