using System.ComponentModel.DataAnnotations;

namespace StoreAppMVC.Models.OrderItems
{
    public class OrderItemModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Количество должно быть больше 0")]
        public decimal Quantity { get; set; }
        public string Unit { get; set; }
        public int OrderId { get; set; }
    }
}
