using BurgerApp.ViewModels.UserViewModels;

namespace BurgerApp.Services.Interfaces
{
    public interface IUserService
    {
        List<UserViewModel> GetUsers();
    }
}
