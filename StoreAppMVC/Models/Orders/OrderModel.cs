using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace StoreAppMVC.Models.Orders
{
    public class OrderModel
    {
        public int Id { get; set; }
        public string Number { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public int ProviderId { get; set; }
        public SelectList? ProviderList { get; set; }
    }
}
