using homework06.Models;
using Microsoft.AspNetCore.Mvc;

namespace homework06.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult BirthdayCardForm()
        {
            return View(new Card());
        }

        [HttpPost]
        public IActionResult BirthdayCardForm(Models.Card cardResponse)
        {
            if (ModelState.IsValid)
            {
                return View("Thanks", cardResponse);
            }
            else
            {
                return View(cardResponse);
            }
        }
    }
}
