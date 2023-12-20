using System.ComponentModel.DataAnnotations;

namespace StoreApp_DataBase.Entities
{
    public class Provider
    {
        public int Id { get; set; }

        [MaxLength]
        public string Name { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
