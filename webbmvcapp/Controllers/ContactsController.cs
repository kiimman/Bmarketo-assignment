using Microsoft.AspNetCore.Mvc;
using webbmvcapp.Contexts;
using webbmvcapp.ViewModels;

namespace webbmvcapp.Controllers
{
    public class ContactsController : Controller
    {
        private readonly IdentityContext _context;
        public ContactsController(IdentityContext identityContext)
        {
            _context = identityContext;
        }
        public IActionResult Index(string msg="",string err="")
        {
            ViewBag.Message = msg;
            ViewBag.Error = err;
            return View();
        }
        [HttpPost]
        public IActionResult PostContact(ContactViewModel contact)
        {
            if (ModelState.IsValid)
            {
                _context.Contacts.Add(contact);
                _context.SaveChanges();
                return RedirectToAction("Index", new {msg="Form submitted successfully."});
            }
            return RedirectToAction("Index", new { err = "Please fill all fields carefully." });
        }
    }
}
