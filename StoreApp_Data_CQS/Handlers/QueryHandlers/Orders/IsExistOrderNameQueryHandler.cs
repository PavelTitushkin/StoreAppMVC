using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreApp_Data_CQS.Queries.Orders;
using StoreApp_DataBase;

namespace StoreApp_Data_CQS.Handlers.QueryHandlers.Orders
{
    public class IsExistOrderNameQueryHandler : IRequestHandler<IsExistOrderNameQuery, bool>
    {
        private readonly StoreAppContext _context;

        public IsExistOrderNameQueryHandler(StoreAppContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(IsExistOrderNameQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Order
                .AsNoTracking()
                .FirstOrDefaultAsync(o => o.Number.ToUpper() == request.Name.ToUpper(), cancellationToken);

            return result == null;
        }
    }
}
