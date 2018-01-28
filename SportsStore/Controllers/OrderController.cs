using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;

namespace SportsStore.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Checkout()
        {
            return View(new Order());
        }
    }
}