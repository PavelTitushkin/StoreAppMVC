using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreApp_Core.DTOs;
using StoreApp_Data_CQS.Queries.Providers;
using StoreApp_DataBase;

namespace StoreApp_Data_CQS.Handlers.QueryHandlers.Providers
{
    public class GetAllProvidersQueryHandler : IRequestHandler<GetAllProvidersQuery, ICollection<ProviderDTO>>
    {
        private readonly StoreAppContext _context;
        private readonly IMapper _mapper;

        public GetAllProvidersQueryHandler(StoreAppContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ICollection<ProviderDTO>> Handle(GetAllProvidersQuery request, CancellationToken cancellationToken)
        {
            return await _context.Provider
                .AsNoTracking()
                .Select(e => _mapper.Map<ProviderDTO>(e))
                .ToListAsync(cancellationToken);
        }
    }
}
