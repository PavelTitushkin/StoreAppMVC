using MediatR;

namespace StoreApp_Data_CQS.Commands.OrderItems
{
    public class DeleteOrderItemCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
