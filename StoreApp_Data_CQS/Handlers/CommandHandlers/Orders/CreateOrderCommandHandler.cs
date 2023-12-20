using MediatR;
using StoreApp_Data_CQS.Commands.Order;
using StoreApp_DataBase;
using StoreApp_DataBase.Entities;

namespace StoreApp_Data_CQS.Handlers.CommandHandlers.Orders
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, bool>
    {
        private readonly StoreAppContext _context;

        public CreateOrderCommandHandler(StoreAppContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var entity = new Order()
            {
                Number = request.Number,
                Date = request.Date,
                ProviderId = request.ProviderId,
            };

            if (!_context.Order.Any(o => o.Number == request.Number && o.ProviderId == request.ProviderId))
            {
                await _context.Order.AddAsync(entity, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
