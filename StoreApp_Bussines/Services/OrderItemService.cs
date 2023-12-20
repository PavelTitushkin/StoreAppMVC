using MediatR;
using StoreApp_Core.Contracts;
using StoreApp_Core.DTOs;
using StoreApp_Data_CQS.Commands.OrderItems;
using StoreApp_Data_CQS.Queries.OrderItems;

namespace StoreApp_Bussines.Services
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IMediator _mediator;

        public OrderItemService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Unit> CreateOrderItemAsync(OrderItemDTO dto)
        {
            return await _mediator.Send(new CreateOrderItemCommand()
            {
                Name = dto.Name,
                Quantity = dto.Quantity,
                Unit = dto.Unit,
                OrderId = dto.OrderId,
            });
        }

        public async Task<Unit> EditOrderItemAsync(OrderItemDTO dto)
        {
            return await _mediator.Send(new EditOrderItemCommand()
            {
                Id = dto.Id,
                Name = dto.Name,
                Quantity = dto.Quantity,
                Unit = dto.Unit,
                OrderId = dto.OrderId,
            });
        }

        public async Task<Unit> DeleteOrderItemAsync(int id)
        {
            return await _mediator.Send(new DeleteOrderItemCommand() { Id = id });
        }

        public async Task<ICollection<OrderItemDTO>?> GetOrderItemsAsync(int id, string? filter)
        {
            return await _mediator.Send(new GetOrderItemsByFilterQuery()
            {
                Id = id,
                Filter = filter
            });
        }
    }
}
