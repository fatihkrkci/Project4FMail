using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules.MessageValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PresentationLayer.Controllers
{
    public class MessageController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMessageService _messageManager;
        private readonly ICategoryService _categoryService;

        public MessageController(UserManager<AppUser> userManager, IMessageService messageManager, ICategoryService categoryService)
        {
            _userManager = userManager;
            _messageManager = messageManager;
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult NewMessage()
        {
            var categories = _categoryService.TGetAll();
            List<SelectListItem> categoryTypes = (from x in categories
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryType.ToString(),
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.CategoryTypes = categoryTypes;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NewMessage(Message message)
        {
            ModelState.Clear();

            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            message.SenderMail = user.Email;
            message.CreatedAt = DateTime.Now;
            message.AppUserId = user.Id;

            CreateMessageValidator validationRules = new CreateMessageValidator();
            ValidationResult result = validationRules.Validate(message);

            if (result.IsValid)
            {
                _messageManager.TInsert(message);
                return RedirectToAction("Sendbox", "Message");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
        }

        public IActionResult Details(int id)
        {
            var message = _messageManager.TGetById(id);
            return View(message);
        }

        public async Task<IActionResult> Inbox()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var messages = _messageManager.TGetInboxWithCategory(user.Email);

            return View(messages);
        }

        public IActionResult Delete(int id)
        {
            var message = _messageManager.TGetById(id);
            message.CategoryId = 5;
            _messageManager.TUpdate(message);
            return RedirectToAction("Trash", "Message");
        }

        public IActionResult PermanentlyDelete(int id)
        {
            _messageManager.TDelete(id);
            return RedirectToAction("Trash", "Message");
        }

        public async Task<IActionResult> Sendbox()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var messages = _messageManager.TGetSendboxWithCategory(user.Email);

            return View(messages);
        }

        public async Task<IActionResult> Primary()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var messages = _messageManager.TGetPrimaryWithCategory(user.Email);

            return View(messages);
        }

        public async Task<IActionResult> Promotions()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var messages = _messageManager.TGetPromotionsWithCategory(user.Email);

            return View(messages);
        }

        public async Task<IActionResult> Social()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var messages = _messageManager.TGetSocialWithCategory(user.Email);

            return View(messages);
        }

        public async Task<IActionResult> Spam()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var messages = _messageManager.TGetSpamWithCategory(user.Email);

            return View(messages);
        }

        public async Task<IActionResult> Trash()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var messages = _messageManager.TGetTrashWithCategory(user.Email);

            return View(messages);
        }

        public async Task<IActionResult> Draft()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var messages = _messageManager.TGetDraftWithCategory(user.Email);

            return View(messages);
        }
    }
}
