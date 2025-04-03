using Microsoft.AspNetCore.Mvc;

namespace TravelBookingPortal.API.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
