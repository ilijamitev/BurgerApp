using BurgerApp.DataAccess.Data;
using BurgerApp.DataAccess.Repositories.Interfaces;
using BurgerApp.Domain.Models;

namespace BurgerApp.DataAccess.Repositories
{
    public class UserRepository : BaseRepository, IRepository<User>
    {
        public UserRepository(BurgerAppDbContext dbContext) : base(dbContext)
        {
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetById(int id)
        {
            return _context.Users.SingleOrDefault(x => x.Id == id)!;
        }

        public void Insert(User entity)
        {
            _context.Users.Add(entity);
            _context.SaveChanges();
        }

        public void Update(User entity)
        {
            _context.Users.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = _context.Users.SingleOrDefault(x => x.Id == id);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
}
