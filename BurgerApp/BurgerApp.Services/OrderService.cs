using AutoMapper;
using BurgerApp.DataAccess.Repositories.Interfaces;
using BurgerApp.Domain.Models;
using BurgerApp.Services.Interfaces;
using BurgerApp.ViewModels.BurgerViewModels;
using BurgerApp.ViewModels.OrderViewModels;

namespace BurgerApp.Services
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<Burger> _burgerRepository;

        public OrderService(IRepository<Order> orderRepository, IMapper mapper, IRepository<Burger> burgerRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
            _burgerRepository = burgerRepository;
        }

        public IEnumerable<OrderViewModel> GetAllOrders()
        {
            var ordersFromDb = _orderRepository.GetAll();
            ArgumentNullException.ThrowIfNull(ordersFromDb);
            var orders = ordersFromDb.Select(_mapper.Map<Order, OrderViewModel>);
            return orders;
        }

        public OrderViewModel GetOrder(int id)
        {
            var order = _orderRepository.GetById(id);
            ArgumentNullException.ThrowIfNull(order);
            var mappedOrder = _mapper.Map<OrderViewModel>(order);
            return mappedOrder;
        }

        public EditOrderViewModel GetOrderToEdit(int id)
        {
            var orderFromDb = _orderRepository.GetById(id);
            var mappedOrder = _mapper.Map<EditOrderViewModel>(orderFromDb);
            return mappedOrder;
        }

        public void CreateOrder(CreateOrderViewModel order)
        {
            var newOrder = _mapper.Map<Order>(order);
            foreach (var burgerId in order.BurgersId)
            {
                newOrder.BurgerOrders?.Add(new BurgerOrder { BurgerId = burgerId, OrderId = newOrder.Id });
            }
            _orderRepository.Insert(newOrder);
        }

        public OrderDetailsViewModel GetOrderDetails(int id)
        {
            var order = _orderRepository.GetById(id);
            var mappedBurgers = order.BurgerOrders.Select(_mapper.Map<BurgerOrder, BurgerViewModel>).ToList();
            var orderDetails = _mapper.Map<OrderDetailsViewModel>(order);
            orderDetails.Burgers = mappedBurgers;
            return orderDetails;
        }

        public void DeleteOrder(int id)
        {
            _orderRepository.Delete(id);
        }

        public void EditOrder(EditOrderViewModel model)
        {
            var order = _orderRepository.GetById(model.Id);
            Order mappedOrder = _mapper.Map(model, order);
            _orderRepository.Update(mappedOrder);
        }


    }
}
