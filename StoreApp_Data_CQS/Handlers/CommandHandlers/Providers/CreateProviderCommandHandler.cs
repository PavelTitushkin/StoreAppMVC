using MediatR;
using StoreApp_Data_CQS.Commands.Provider;
using StoreApp_DataBase;
using StoreApp_DataBase.Entities;

namespace StoreApp_Data_CQS.Handlers.CommandHandlers.Providers
{
    public class CreateProviderCommandHandler : IRequestHandler<CreateProviderCommand, Unit>
    {
        private readonly StoreAppContext _context;

        public CreateProviderCommandHandler(StoreAppContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateProviderCommand request, CancellationToken cancellationToken)
        {
            var entity = new Provider()
            {
                Name = request.Name,
            };

            await _context.Provider.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
