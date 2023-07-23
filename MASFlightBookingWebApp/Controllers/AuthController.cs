using Microsoft.AspNetCore.Mvc;

namespace MASFlightBookingWebApp.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
