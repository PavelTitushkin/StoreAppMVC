using MediatR;

namespace StoreApp_Data_CQS.Commands.Provider
{
    public class CreateProviderCommand : IRequest<Unit>
    {
        public string Name { get; set; }
    }
}
