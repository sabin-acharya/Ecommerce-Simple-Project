using Microsoft.AspNetCore.Mvc;

namespace Shopping.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult AdminIndex()
        {
            return View();
        }
    }
}
