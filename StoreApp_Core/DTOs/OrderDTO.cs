namespace StoreApp_Core.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public ProviderDTO ProviderDTO { get; set; }
        public int ProviderDTOId { get; set; }
        public ICollection<OrderItemDTO> OrderItemDTOs { get; set; }
    }
}
