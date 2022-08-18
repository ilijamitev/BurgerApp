using BurgerApp.DataAccess.Data;
using BurgerApp.DataAccess.Repositories.Interfaces;
using BurgerApp.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BurgerApp.DataAccess.Repositories
{
    public class OrderRepository : IRepository<Order>
    {
        private readonly BurgerAppDbContext _context;
        public OrderRepository(BurgerAppDbContext context)
        {
            _context = context;
        }

        public List<Order> GetAll()
        {
            return _context.Orders
                .Include(x => x.User)
                .Include(x => x.BurgerOrders).ThenInclude(x => x.Burger).ToList();
        }

        public Order GetById(int id)
        {
            return _context.Orders
                .Include(x => x.BurgerOrders).ThenInclude(x => x.Burger)
                .Include(x => x.User)
                .SingleOrDefault(x => x.Id == id)!;
        }

        public void Insert(Order entity)
        {
            _context.Orders.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Order entity)
        {
            _context.Orders.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Order order = _context.Orders.SingleOrDefault(x => x.Id == id)!;
            _context.Orders.Remove(order);
            _context.SaveChanges();
        }
    }
}
