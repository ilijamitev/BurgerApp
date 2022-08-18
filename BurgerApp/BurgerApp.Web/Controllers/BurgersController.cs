using BurgerApp.Services.Interfaces;
using BurgerApp.ViewModels.BurgerViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BurgerApp.Web.Controllers
{
    [Route("burgers")]
    public class BurgersController : Controller
    {
        private readonly IBurgerService _bugerService;
        public BurgersController(IBurgerService burgerService)
        {
            _bugerService = burgerService;
        }

        [HttpGet("all")]
        public IActionResult Index()
        {
            List<BurgerViewModel> burgersFromDb = _bugerService.GetAllBurgers();
            return View(burgersFromDb);
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            CreateBurgerViewModel model = new();
            return View(model);
        }

        [HttpPost("create")]
        public IActionResult Create(CreateBurgerViewModel newBurger)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (newBurger.Price <= 0)
                    {
                        throw new Exception("The price must be greather than zero!");
                    }
                    _bugerService.AddNewBurger(newBurger);
                    return RedirectToAction("Index");
                }

                return View();
            }
            catch (Exception ex)
            {
                ViewBag.ReturnView = "Create";
                ViewBag.ErrorTitle = "Failed creating new burger!";
                ViewBag.ErrorMessage = $"{ex.Message}";
                return View("_ErrorView");
            }
        }

        [HttpGet("edit")]
        public IActionResult Edit(int id)
        {
            var burger = _bugerService.GetBurgerById(id);
            return View(burger);
        }

        [HttpPost("edit")]
        public IActionResult Edit(BurgerViewModel burger)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (burger.Price <= 0)
                    {
                        throw new Exception("The price must be greather than zero!");
                    }
                    _bugerService.EditBurger(burger);
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.ReturnView = "Index";
                ViewBag.ErrorTitle = "Failed editing burger!";
                ViewBag.ErrorMessage = $"{ex.Message}";
                return View("_ErrorView");
            }
        }

        [HttpGet("delete")]
        public IActionResult Delete(int id)
        {
            var burger = _bugerService.GetBurgerById(id);
            return View(burger);
        }

        [HttpPost("delete")]
        public IActionResult ConfirmDelete(int id)
        {
            _bugerService.DeleteBurger(id);
            return RedirectToAction("Index");
        }


    }
}
