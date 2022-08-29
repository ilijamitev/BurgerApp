using BurgerApp.Services.Interfaces;
using BurgerApp.ViewModels.ErrorViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BurgerApp.Web.Controllers
{
    [Route("orders")]
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IBurgerService _burgerService;
        public OrdersController(IBurgerService burgerService, IOrderService orderService)
        {
            _burgerService = burgerService;
            _orderService = orderService;
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



    }
}
