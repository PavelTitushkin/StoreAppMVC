using MediatR;
using StoreApp_Data_CQS.Commands.OrderItems;
using StoreApp_DataBase;
using StoreApp_DataBase.Entities;

namespace StoreApp_Data_CQS.Handlers.CommandHandlers.OrderItems
{
    public class CreateOrderItemCommandHandler : IRequestHandler<CreateOrderItemCommand, Unit>
    {
        private readonly StoreAppContext _context;

        public CreateOrderItemCommandHandler(StoreAppContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateOrderItemCommand request, CancellationToken cancellationToken)
        {
            var entity = new OrderItem()
            {
                Name = request.Name,
                Quantity = request.Quantity,
                Unit = request.Unit,
                OrderId = request.OrderId,
            };

            await _context.OrderItem.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
