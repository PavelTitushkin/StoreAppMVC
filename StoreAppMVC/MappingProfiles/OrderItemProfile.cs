using AutoMapper;
using StoreApp_Core.DTOs;
using StoreApp_DataBase.Entities;

namespace StoreApp.MappingProfiles
{
    public class OrderItemProfile : Profile
    {
        public OrderItemProfile()
        {
            CreateMap<OrderItem, OrderItemDTO>();

            CreateMap<OrderItemDTO, OrderItem>();
        }
    }
}
