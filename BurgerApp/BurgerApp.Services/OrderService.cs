using AutoMapper;
using BurgerApp.DataAccess.Repositories.Interfaces;
using BurgerApp.Domain.Models;
using BurgerApp.Services.Interfaces;
using BurgerApp.ViewModels.OrderViewModels;

namespace BurgerApp.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IRepository<Order> orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public IEnumerable<OrderViewModel> GetAllOrders()
        {
            var ordersFromDb = _orderRepository.GetAll();
            ArgumentNullException.ThrowIfNull(ordersFromDb);
            var orders = ordersFromDb.Select(_mapper.Map<Order, OrderViewModel>);
            return orders;
        }

        public OrderDetailsViewModel GetOrderDetails(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteOrder(int id)
        {
            throw new NotImplementedException();
        }

        public void EditOrder(OrderViewModel model)
        {
            throw new NotImplementedException();
        }


    }
}
