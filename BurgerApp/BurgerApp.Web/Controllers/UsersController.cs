using Microsoft.AspNetCore.Mvc;

namespace BurgerApp.Web.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
