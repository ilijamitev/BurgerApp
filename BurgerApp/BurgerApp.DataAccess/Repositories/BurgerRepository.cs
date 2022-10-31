using BurgerApp.DataAccess.Data;
using BurgerApp.DataAccess.Repositories.Interfaces;
using BurgerApp.Domain.Models;

namespace BurgerApp.DataAccess.Repositories
{
    public class BurgerRepository : BaseRepository, IRepository<Burger>
    {
        public BurgerRepository(BurgerAppDbContext dbContext) : base(dbContext)
        {
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
            _context.Burgers.Remove(burger);
            _context.SaveChanges();
        }

    }
}
