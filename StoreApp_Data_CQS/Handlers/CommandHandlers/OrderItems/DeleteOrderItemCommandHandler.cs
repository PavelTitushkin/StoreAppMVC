using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreApp_Data_CQS.Commands.OrderItems;
using StoreApp_DataBase;

namespace StoreApp_Data_CQS.Handlers.CommandHandlers.OrderItems
{
    public class DeleteOrderItemCommandHandler : IRequestHandler<DeleteOrderItemCommand, Unit>
    {
        private readonly StoreAppContext _context;

        public DeleteOrderItemCommandHandler(StoreAppContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteOrderItemCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.OrderItem
                .Where(oi => oi.Id == request.Id)
                .FirstOrDefaultAsync(cancellationToken);

            if (entity != null)
            {
                _context.OrderItem.Remove(entity);
                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }

            return Unit.Value;
        }
    }
}
