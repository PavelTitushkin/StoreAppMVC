using AutoMapper;
using StoreApp_Core.DTOs;
using StoreApp_DataBase.Entities;

namespace StoreApp.MappingProfiles
{
    public class ProviderProfile : Profile
    {
        public ProviderProfile()
        {
            CreateMap<Provider, ProviderDTO>();
            CreateMap<ProviderDTO, Provider>();
        }
    }
}
