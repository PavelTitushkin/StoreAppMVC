using MediatR;

namespace StoreApp_Data_CQS.Queries.Orders
{
    public class IsExistOrderNameQuery : IRequest<bool>
    {
        public string Name { get; set; }
    }
}
