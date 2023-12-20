using MediatR;
using StoreApp_Core.Contracts;
using StoreApp_Core.DTOs;
using StoreApp_Data_CQS.Commands.Provider;
using StoreApp_Data_CQS.Queries.Providers;

namespace StoreApp_Bussines.Services
{
    public class ProviderService : IProviderService
    {
        private readonly IMediator _mediator;

        public ProviderService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Unit> CreateProviderAsync(ProviderDTO dto)
        {
            return await _mediator.Send(new CreateProviderCommand() { Name = dto.Name });
        }

        public async Task<ICollection<ProviderDTO>> GetAllProvidersAsync()
        {
            return await _mediator.Send(new GetAllProvidersQuery());
        }
    }
}
