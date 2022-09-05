using BurgerApp.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace BurgerApp.ViewModels.OrderViewModels
{
    public class EditOrderViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Payment Method")]
        public PaymentMethod PaymentMethod { get; set; }
        [Display(Name = "Is Delivered")]
        public bool IsDelivered { get; set; }

    }
}
