using MediatR;

namespace StoreApp_Data_CQS.Commands.OrderItems
{
    public class CreateOrderItemCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Quantity { get; set; }
        public string Unit { get; set; }
        public int OrderId { get; set; }
    }
}
