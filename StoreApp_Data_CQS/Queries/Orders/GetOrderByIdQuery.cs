using MediatR;
using StoreApp_Core.DTOs;

namespace StoreApp_Data_CQS.Queries.Orders
{
    public class GetOrderByIdQuery : IRequest<OrderDTO?>
    {
        public int Id { get; set; }
    }
}
