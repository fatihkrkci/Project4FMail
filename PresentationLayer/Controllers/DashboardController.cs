using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class DashboardController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public DashboardController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            //var user = await _userManager.FindByNameAsync(User.Identity.Name);
            //var values = _articleService.TGetArticlesByAppUserId(userValue.Id);
            return View();
        }
    }
}
