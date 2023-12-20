using MediatR;
using StoreApp_Core.DTOs;

namespace StoreApp_Data_CQS.Queries.Providers
{
    public class GetAllProvidersQuery : IRequest<ICollection<ProviderDTO>>
    {
    }
}
