using AutoMapper;
using StoreApp_Core.DTOs;
using StoreApp_DataBase.Entities;

namespace StoreApp.MappingProfiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDTO>()
                .ForMember(dto => dto.ProviderDTOId, opt => opt.MapFrom(opt => opt.ProviderId))
                .ForMember(dto => dto.ProviderDTO, opt => opt.MapFrom(opt => opt.Provider))
                .ForMember(dto => dto.OrderItemDTOs, opt => opt.MapFrom(opt => opt.OrderItems));

            CreateMap<OrderDTO, Order>();
        }
    }
}
