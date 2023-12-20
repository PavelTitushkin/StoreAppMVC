using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreApp_Core.DTOs;
using StoreApp_Data_CQS.Queries.Orders;
using StoreApp_DataBase;

namespace StoreApp_Data_CQS.Handlers.QueryHandlers.Orders
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderDTO?>
    {
        private readonly StoreAppContext _context;
        private readonly IMapper _mapper;

        public GetOrderByIdQueryHandler(StoreAppContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OrderDTO?> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Order
                .AsNoTracking()
                .Where(o => o.Id == request.Id)
                .Include(p => p.Provider)
                .Select(e => _mapper.Map<OrderDTO>(e))
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
