using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryDream.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            ViewBag.CurrentUserName = User.Identity.Name;
            return View();
        }
        [Route("/Error")]
        public IActionResult Error()
        {
            return View();
        }
    }
}
