using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult EditMyProfile()
        {
            return View();
        }
    }
}
