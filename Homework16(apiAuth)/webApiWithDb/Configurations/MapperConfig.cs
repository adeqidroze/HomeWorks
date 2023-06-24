
using AutoMapper;
using Database.Domain;
using webApiWithDb.DTOs;
using webApiWithDb.Models;

namespace webApiWithDb.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Person,
                PersonDto>().ReverseMap();
            CreateMap<Address,
                AddressDto>().ReverseMap();
            CreateMap<Credentials,
                CredentialsDto>().ReverseMap();

        }
    }
}
