using BurgerApp.ViewModels.BurgerViewModels;

namespace BurgerApp.Services.Interfaces
{
    public interface IBurgerService
    {
        List<BurgerViewModel> GetAllBurgers();
        BurgerViewModel GetBurgerById(int id);
        void AddNewBurger(CreateBurgerViewModel model);
        void DeleteBurger(int id);
        void EditBurger(BurgerViewModel model);

    }
}
