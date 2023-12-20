using MediatR;
using StoreApp_Core.DTOs;

namespace StoreApp_Data_CQS.Queries.Orders
{
    public class GetOrdersByFilterQuery : IRequest<ICollection<OrderDTO>?>
    {
        public DateTime SearchDateStart { get; set; }
        public DateTime SearchDateEnd { get; set; }
        public string? Filter { get; set; }
    }
}
