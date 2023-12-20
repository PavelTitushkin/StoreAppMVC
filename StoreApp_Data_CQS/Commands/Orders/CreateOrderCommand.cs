using MediatR;

namespace StoreApp_Data_CQS.Commands.Order
{
    public class CreateOrderCommand : IRequest<bool>
    {
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public int ProviderId { get; set; }
    }
}
