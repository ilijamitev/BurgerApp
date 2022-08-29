using BurgerApp.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace BurgerApp.ViewModels.OrderViewModels
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        [Display(Name = "Full Name")]
        public string UserFullName { get; set; }
        [Display(Name = "Delivered")]
        public bool IsDelivered { get; set; }
        [Display(Name = "Total Price")]
        public double TotalPrice { get; set; }

    }
}
