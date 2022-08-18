using BurgerApp.Domain.Enums;
using BurgerApp.ViewModels.BurgerViewModels;

namespace BurgerApp.ViewModels.OrderViewModels
{
    public class OrderDetailsViewModel
    {
        public int OrderId { get; set; }
        public string UserFullName { get; set; }
        public string Address { get; set; }
        public bool IsDelivered { get; set; }
        public double TotalPrice { get; set; }
        public DateTime TimeOrdered { get; set; }
        public string Location { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public List<BurgerViewModel> Burgers { get; set; }
    }
}
