using BurgerApp.ViewModels.OrderViewModels;

namespace BurgerApp.Services.Interfaces
{
    public interface IOrderService
    {
        public IEnumerable<OrderViewModel> GetAllOrders();
        public OrderDetailsViewModel GetOrderDetails(int id);
        public void EditOrder(OrderViewModel model);
        public void DeleteOrder(int id);

    }
}
