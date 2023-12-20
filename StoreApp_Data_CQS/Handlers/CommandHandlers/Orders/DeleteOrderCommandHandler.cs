using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreApp_Data_CQS.Commands.Order;
using StoreApp_DataBase;

namespace StoreApp_Data_CQS.Handlers.CommandHandlers.Orders
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, Unit>
    {
        private readonly StoreAppContext _context;

        public DeleteOrderCommandHandler(StoreAppContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Order
                .Where(o => o.Id == request.Id)
                .FirstOrDefaultAsync(cancellationToken);

            if (entity != null)
            {
                _context.Order.Remove(entity);
                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }

            return Unit.Value;
        }
    }
}
