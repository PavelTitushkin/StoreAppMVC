using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreApp_Data_CQS.Commands.Order;
using StoreApp_DataBase;

namespace StoreApp_Data_CQS.Handlers.CommandHandlers.Orders
{
    public class EditOrderCommandHandler : IRequestHandler<EditOrderCommand, Unit>
    {
        private readonly StoreAppContext _context;

        public EditOrderCommandHandler(StoreAppContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(EditOrderCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Order
                .Where(o => o.Id == request.Id)
                .FirstOrDefaultAsync(cancellationToken);

            if (entity != null)
            {
                entity.Number = request.Number;
                entity.Date = request.Date;
                entity.ProviderId = request.ProviderDTOId;

                _context.Order.Update(entity);
                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }

            return Unit.Value;
        }
    }
}
