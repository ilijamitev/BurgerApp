using BurgerApp.Domain.Enums;
using BurgerApp.Domain.Models;
using BurgerApp.ViewModels.BurgerViewModels;

namespace BurgerApp.ViewModels.OrderViewModels
{
    public class CreateOrderViewModel
    {
        public int UserId { get; set; }
        public DateTime TimeOrdered { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public List<int> BurgersId { get; set; }

    }
}
