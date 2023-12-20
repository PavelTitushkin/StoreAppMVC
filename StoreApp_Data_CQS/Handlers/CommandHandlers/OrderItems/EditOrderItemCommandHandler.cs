using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreApp_Data_CQS.Commands.OrderItems;
using StoreApp_DataBase;

namespace StoreApp_Data_CQS.Handlers.CommandHandlers.OrderItems
{
    public class EditOrderItemCommandHandler : IRequestHandler<EditOrderItemCommand, Unit>
    {
        private readonly StoreAppContext _context;

        public EditOrderItemCommandHandler(StoreAppContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(EditOrderItemCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.OrderItem
                .Where(oi => oi.Id == request.Id)
                .FirstOrDefaultAsync(cancellationToken);

            if (entity != null)
            {
                entity.Name = request.Name;
                entity.Quantity = request.Quantity;
                entity.Unit = request.Unit;

                _context.OrderItem.Update(entity);
                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }

            return Unit.Value;
        }
    }
}
