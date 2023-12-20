using System.ComponentModel.DataAnnotations;

namespace StoreApp_DataBase.Entities
{
    public class Order
    {
        public int Id { get; set; }

        [MaxLength]
        public string Number { get; set; }

        public DateTime Date { get; set; }

        public Provider Provider { get; set; }
        public int ProviderId { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}