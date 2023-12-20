using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreApp_Core.DTOs;
using StoreApp_Data_CQS.Queries.OrderItems;
using StoreApp_DataBase;

namespace StoreApp_Data_CQS.Handlers.QueryHandlers.OrderItems
{
    public class GetOrderItemsByFilterQueryHandler : IRequestHandler<GetOrderItemsByFilterQuery, ICollection<OrderItemDTO>?>
    {
        private readonly StoreAppContext _context;
        private readonly IMapper _mapper;

        public GetOrderItemsByFilterQueryHandler(StoreAppContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ICollection<OrderItemDTO>?> Handle(GetOrderItemsByFilterQuery request, CancellationToken cancellationToken)
        {
            switch (request.Filter)
            {
                case "nameOrderItemFirst":
                    return await _context.OrderItem
                        .AsNoTracking()
                        .Where(oi => oi.OrderId == request.Id)
                        .OrderBy(oi => oi.Name)
                        .Select(e => _mapper.Map<OrderItemDTO>(e))
                        .ToListAsync(cancellationToken);
                case "nameOrderItemLast":
                    return await _context.OrderItem
                        .AsNoTracking()
                        .Where(oi => oi.OrderId == request.Id)
                        .OrderByDescending(oi => oi.Name)
                        .Select(e => _mapper.Map<OrderItemDTO>(e))
                        .ToListAsync(cancellationToken);

                case "quantityFirst":
                    return await _context.OrderItem
                        .AsNoTracking()
                        .Where(oi => oi.OrderId == request.Id)
                        .OrderBy(oi => oi.Quantity)
                        .Select(e => _mapper.Map<OrderItemDTO>(e))
                        .ToListAsync(cancellationToken);
                case "quantityLast":
                    return await _context.OrderItem
                        .AsNoTracking()
                        .Where(oi => oi.OrderId == request.Id)
                        .OrderByDescending(oi => oi.Quantity)
                        .Select(e => _mapper.Map<OrderItemDTO>(e))
                        .ToListAsync(cancellationToken);

                case "unitFirst":
                    return await _context.OrderItem
                        .AsNoTracking()
                        .Where(oi => oi.OrderId == request.Id)
                        .OrderBy(oi => oi.Unit)
                        .Select(e => _mapper.Map<OrderItemDTO>(e))
                        .ToListAsync(cancellationToken);
                case "unitLast":
                    return await _context.OrderItem
                        .AsNoTracking()
                        .Where(oi => oi.OrderId == request.Id)
                        .OrderByDescending(oi => oi.Unit)
                        .Select(e => _mapper.Map<OrderItemDTO>(e))
                        .ToListAsync(cancellationToken);

                default:
                    return await _context.OrderItem
                        .AsNoTracking()
                        .Where(oi => oi.OrderId == request.Id)
                        .OrderBy(oi => oi.Name)
                        .Select(e => _mapper.Map<OrderItemDTO>(e))
                        .ToListAsync(cancellationToken);
            }
        }
    }
}
