namespace StoreAppMVC.Exceptions
{
    public class OrderNumberIsNotUniqueException : Exception
    {
        public OrderNumberIsNotUniqueException(string? message) : base(message)
        {
        }
    }
}
