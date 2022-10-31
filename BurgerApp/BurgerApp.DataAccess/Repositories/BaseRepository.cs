using BurgerApp.DataAccess.Data;

namespace BurgerApp.DataAccess.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly BurgerAppDbContext _context;

        protected BaseRepository(BurgerAppDbContext dbContext)
        {
            _context = dbContext;
        }
    }
}
