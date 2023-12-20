using System.ComponentModel.DataAnnotations;

namespace StoreApp_DataBase.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }

        [MaxLength]
        public string Name { get; set; }
        public decimal Quantity { get; set; }

        [MaxLength]
        public string Unit { get; set; }

        public Order Order { get; set; }
        public int OrderId { get; set; }
    }
}
