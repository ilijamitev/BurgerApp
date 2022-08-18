using BurgerApp.DataAccess.Data;
using BurgerApp.DataAccess.Repositories.Interfaces;
using BurgerApp.Domain.Models;

namespace BurgerApp.DataAccess.Repositories
{
    public class BurgerRepository : IRepository<Burger>
    {
        private readonly BurgerAppDbContext _context;
        public BurgerRepository(BurgerAppDbContext context)
        {
            _context = context;
        }

        public List<Burger> GetAll()
        {
            return _context.Burgers.ToList();
        }

        public Burger GetById(int id)
        {
            return _context.Burgers.SingleOrDefault(x => x.Id == id)!;
        }

        public void Insert(Burger entity)
        {
            _context.Burgers.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Burger entity)
        {
            _context.Burgers.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Burger burger = _context.Burgers.SingleOrDefault(x => x.Id == id)!;
            //ArgumentNullException.ThrowIfNull(burger); // MNOGU KORISNO
            _context.Burgers.Remove(burger);
            _context.SaveChanges();
        }

    }
}
