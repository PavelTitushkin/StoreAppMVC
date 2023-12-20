using MediatR;
using StoreApp_Core.DTOs;

namespace StoreApp_Data_CQS.Queries.OrderItems
{
    public class GetOrderItemsByFilterQuery : IRequest<ICollection<OrderItemDTO>?>
    {
        public int Id { get; set; }
        public string? Filter { get; set; }
    }
}
