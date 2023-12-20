using MediatR;

namespace StoreApp_Data_CQS.Commands.Order
{
    public class DeleteOrderCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
