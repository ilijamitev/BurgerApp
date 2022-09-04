using BurgerApp.Domain.Enums;
using BurgerApp.Domain.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BurgerApp.ViewModels.OrderViewModels
{
    public class CreateOrderViewModel
    {
        public int Id { get; set; }
        [DisplayName("Select User")]
        [Required(ErrorMessage = "Please select User!")]
        public int UserId { get; set; }
        public DateTime TimeOrdered { get; set; }
        [DisplayName("Payment Method")]
        public PaymentMethod PaymentMethod { get; set; }
        [DisplayName("Select Burgers")]
        [Required(ErrorMessage = "Please select Burger!")]
        public List<int> BurgersId { get; set; }
        public List<BurgerOrder>? BurgerOrders { get; set; }
    }
}
