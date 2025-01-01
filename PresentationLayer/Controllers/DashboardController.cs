using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class DashboardController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ICategoryService _categoryService;

        public DashboardController(UserManager<AppUser> userManager, ICategoryService categoryService)
        {
            _userManager = userManager;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.UserFirstName = user.Name;
            return View();
        }
    }
}
