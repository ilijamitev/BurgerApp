using BurgerApp.Services.Interfaces;
using BurgerApp.ViewModels.ErrorViewModels;
using BurgerApp.ViewModels.OrderViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Serilog;

namespace BurgerApp.Web.Controllers
{
    [Route("orders")]
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IBurgerService _burgerService;
        private readonly IUserService _userService;
        public OrdersController(IBurgerService burgerService, IOrderService orderService, IUserService userService)
        {
            _burgerService = burgerService;
            _orderService = orderService;
            _userService = userService;
        }

        [HttpGet("all")]
        public IActionResult Index()
        {
            var model = _orderService.GetAllOrders();
            if (model is not null)
            {
                return View(model);
            }

            var errorModel = new ErrorViewModel
            {
                ControllerName = "Home",
                ActionName = "Index",
                ErrorMessage = "There aren't any orders yet.",
                ErrorTitle = "No orders!"
            };

            return View("_ErrorView", errorModel);
        }

        [HttpGet("details")]
        public IActionResult Details(int id)
        {
            var order = _orderService.GetOrderDetails(id);
            return View(order);
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            ViewBag.Users = _userService.GetUsers();
            ViewBag.Burgers = _burgerService.GetAllBurgers();
            var model = new CreateOrderViewModel();
            return View(model);
        }

        [HttpPost("create")]
        public IActionResult Create(CreateOrderViewModel newOrder)
        {
            if (ModelState.IsValid)
            {
                newOrder.TimeOrdered = DateTime.Now;
                _orderService.CreateOrder(newOrder);
                return RedirectToAction("Index");
            }
            return View(newOrder);
        }

        [HttpGet("edit")]
        public IActionResult Edit(int id)
        {
            var model = _orderService.GetOrderToEdit(id);
            return View(model);
        }

        [HttpPost("edit")]
        public IActionResult Edit(EditOrderViewModel order)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _orderService.EditOrder(order);
                    return RedirectToAction("Index");
                }
                return View(order);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                throw;
            }

        }

        [HttpGet("delete")]
        public IActionResult Delete(int id)
        {
            try
            {
                var model = _orderService.GetOrder(id);
                return View(model);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                throw;
            }
        }

        public IActionResult ConfirmDelete(int id)
        {
            try
            {
                _orderService.DeleteOrder(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                throw;
            }
        }

    }
}
