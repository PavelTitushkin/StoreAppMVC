using MediatR;
using Microsoft.Extensions.Options;
using StoreApp_Core.Contracts;
using StoreApp_Core.DTOs;
using StoreApp_Core.ModelConfig;
using StoreApp_Data_CQS.Commands.Order;
using StoreApp_Data_CQS.Queries.Orders;

namespace StoreApp_Bussines.Services
{
    public class OrderService : IOrderService
    {
        private readonly IMediator _mediator;
        public AppSettings AppSettings;
        public OrderService(IMediator mediator, IOptions<AppSettings> options)
        {
            _mediator = mediator;
            AppSettings = options.Value;
        }

        public async Task<OrderDTO?> GetOrderByIdAsync(int id)
        {
            return await _mediator.Send(new GetOrderByIdQuery { Id = id });
        }

        public async Task<ICollection<OrderDTO>?> GetOrdersByFilterAsync(DateTime searchDateStart, DateTime searchDateEnd, string? filter)
        {
            if (filter == null)
            {
                return await _mediator.Send(new GetOrdersByFilterQuery()
                {
                    SearchDateStart = DateTime.Now.AddMonths(AppSettings.Month),
                    SearchDateEnd = DateTime.Now,
                    Filter = filter
                });
            }
            else
            {
                return await _mediator.Send(new GetOrdersByFilterQuery()
                {
                    SearchDateStart = searchDateStart,
                    SearchDateEnd = searchDateEnd,
                    Filter = filter
                });
            }
        }

        public async Task<bool> CreateOrderAsync(OrderDTO order)
        {
            return await _mediator.Send(new CreateOrderCommand()
            {
                Number = order.Number,
                Date = order.Date,
                ProviderId = order.ProviderDTOId
            });
        }

        public async Task<Unit> EditOrderAsync(OrderDTO order)
        {
            return await _mediator.Send(new EditOrderCommand()
            {
                Id = order.Id,
                Number = order.Number,
                Date = order.Date,
                ProviderDTOId = order.ProviderDTOId
            });
        }

        public async Task<Unit> DeleteOrderAsync(int id)
        {
            return await _mediator.Send(new DeleteOrderCommand() { Id = id });
        }

        public async Task<bool> IsExistOrderNameAsync(string name)
        {
            return await _mediator.Send(new IsExistOrderNameQuery() { Name = name });
        }
    }
}
