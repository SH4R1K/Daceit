using Microsoft.AspNetCore.Mvc;

namespace DaceItFront.Controllers
{
    public class HubController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
