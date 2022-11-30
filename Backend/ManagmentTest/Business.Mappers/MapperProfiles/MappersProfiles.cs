using AutoMapper;
using Business.Mappers.Dto;
using Persistance.Domain.Entities;

namespace Business.Mappers.MapperProfiles
{
    public class MappersProfiles : Profile
    {
        public MappersProfiles()
        {
            CreateMap<Client, ClientDto>().ReverseMap();
            CreateMap<ClientAddress, ClientAddressDto>().ReverseMap();
            CreateMap<ClientNumber, ClientNumberDto>().ReverseMap();
        }
    }
}
