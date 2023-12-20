using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreApp_Core.DTOs;
using StoreApp_Data_CQS.Queries.Orders;
using StoreApp_DataBase;

namespace StoreApp_Data_CQS.Handlers.QueryHandlers.Orders
{
    public class GetOrdersByFilterQueryHandler : IRequestHandler<GetOrdersByFilterQuery, ICollection<OrderDTO>?>
    {
        private readonly StoreAppContext _context;
        private readonly IMapper _mapper;

        public GetOrdersByFilterQueryHandler(StoreAppContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ICollection<OrderDTO>?> Handle(GetOrdersByFilterQuery request, CancellationToken cancellationToken)
        {
            switch (request.Filter)
            {
                case "dateStart":
                    return await _context.Order
                    .AsNoTracking()
                    .Where(o => o.Date <= request.SearchDateEnd && o.Date >= request.SearchDateStart)
                    .Include(p => p.Provider)
                    .OrderByDescending(o => o.Date)
                    .Select(e => _mapper.Map<OrderDTO>(e))
                    .ToListAsync(cancellationToken);
                case "dateEnd":
                    return await _context.Order
                    .AsNoTracking()
                    .Where(o => o.Date <= request.SearchDateEnd && o.Date >= request.SearchDateStart)
                    .Include(p => p.Provider)
                    .OrderBy(o => o.Date)
                    .Select(e => _mapper.Map<OrderDTO>(e))
                    .ToListAsync(cancellationToken);

                case "numberFirst":
                    return await _context.Order
                    .AsNoTracking()
                    .Where(o => o.Date <= request.SearchDateEnd && o.Date >= request.SearchDateStart)
                    .Include(p => p.Provider)
                    .OrderBy(o => o.Number)
                    .Select(e => _mapper.Map<OrderDTO>(e))
                    .ToListAsync(cancellationToken);
                case "numberLast":
                    return await _context.Order
                    .AsNoTracking()
                    .Where(o => o.Date <= request.SearchDateEnd && o.Date >= request.SearchDateStart)
                    .Include(p => p.Provider)
                    .OrderByDescending(o => o.Number)
                    .Select(e => _mapper.Map<OrderDTO>(e))
                    .ToListAsync(cancellationToken);

                case "providerFirst":
                    return await _context.Order
                    .AsNoTracking()
                    .Where(o => o.Date <= request.SearchDateEnd && o.Date >= request.SearchDateStart)
                    .Include(p => p.Provider)
                    .OrderBy(o => o.Provider)
                    .Select(e => _mapper.Map<OrderDTO>(e))
                    .ToListAsync(cancellationToken);
                case "providerLast":
                    return await _context.Order
                    .AsNoTracking()
                    .Where(o => o.Date <= request.SearchDateEnd && o.Date >= request.SearchDateStart)
                    .Include(p => p.Provider)
                    .OrderByDescending(o => o.Provider)
                    .Select(e => _mapper.Map<OrderDTO>(e))
                    .ToListAsync(cancellationToken);

                default:
                    return await _context.Order
                    .AsNoTracking()
                    .Where(o => o.Date <= request.SearchDateEnd && o.Date >= request.SearchDateStart)
                    .Include(p => p.Provider)
                    .OrderBy(o => o.Date)
                    .Select(e => _mapper.Map<OrderDTO>(e))
                    .ToListAsync(cancellationToken);
            }
        }
    }
}
