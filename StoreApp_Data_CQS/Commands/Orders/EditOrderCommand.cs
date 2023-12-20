using MediatR;

namespace StoreApp_Data_CQS.Commands.Order
{
    public class EditOrderCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public int ProviderDTOId { get; set; }
    }
}
