using BurgerApp.ViewModels.OrderViewModels;

namespace BurgerApp.Services.Interfaces
{
    public interface IOrderService
    {
        public IEnumerable<OrderViewModel> GetAllOrders();
        public OrderViewModel GetOrder(int id);
        public EditOrderViewModel GetOrderToEdit(int id);
        public OrderDetailsViewModel GetOrderDetails(int id);
        public void CreateOrder(CreateOrderViewModel order);
        public void EditOrder(EditOrderViewModel model);
        public void DeleteOrder(int id);

    }
}
