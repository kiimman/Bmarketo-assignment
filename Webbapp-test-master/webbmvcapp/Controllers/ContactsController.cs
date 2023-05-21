using Microsoft.AspNetCore.Mvc;

namespace webbmvcapp.Controllers
{
    public class ContactsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
