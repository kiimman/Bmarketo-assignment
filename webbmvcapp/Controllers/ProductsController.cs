using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using webbmvcapp.Contexts;
using webbmvcapp.Models;
using webbmvcapp.Models.Identity;
using webbmvcapp.ViewModels;

namespace webbmvcapp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IdentityContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly UserManager<CustomIdentityUser> _userManager;

        public ProductsController(IdentityContext context, IWebHostEnvironment webHostEnvironment,UserManager<CustomIdentityUser> userManager)
        {
            _context = context;
            this.webHostEnvironment = webHostEnvironment;
            this._userManager = userManager;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
              return _context.Products != null ? 
                          View(await _context.Products.ToListAsync()) :
                          Problem("Entity set 'IdentityContext.Products'  is null.");
        }
        // GET: Products
        public async Task<IActionResult> GetAllUsers()
        {
            IEnumerable<CustomIdentityUser> list = _context.Users.Select(x=>new CustomIdentityUser { FirstName=x.FirstName,LastName=x.LastName,Email=x.Email,PhoneNumber=x.PhoneNumber,RoleName="Standard User"}).Skip(1);
            return View(list.ToList());
        }
        
        public async Task<IActionResult> GetAllContacts()
        {
            IEnumerable<ContactViewModel> list = _context.Contacts;
            return View(list.ToList());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewBag.list = new SelectList(new List<SelectListItem>
            {
                new SelectListItem{Text="New",Value="New"},
                new SelectListItem{Text="Popular",Value="Popular"},
                new SelectListItem{Text="Featured",Value="Featured"}
            }, "Value", "Text");
            return View();
        }

        // POST: Products/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Category,Price,Quantity,File")] Product product)
        {
            if (ModelState.IsValid)
            {
                if (product.File!=null)
                {
string imageUrl = UploadedFile(product);
                product.ImageURL = "/ProductImages/" + imageUrl;
                }
                
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.list = new SelectList(new List<SelectListItem>
            {
                new SelectListItem{Text="New",Value="New"},
                new SelectListItem{Text="Popular",Value="Popular"},
                new SelectListItem{Text="Featured",Value="Featured"}
            }, "Value", "Text",product.Category);
            return View(product);
        }
        private string UploadedFile(Product product)
        {
            string uniqueFileName = "";

            if (product.File != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "ProductImages");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + product.File.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    product.File.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewBag.list = new SelectList(new List<SelectListItem>
            {
                new SelectListItem{Text="New",Value="New"},
                new SelectListItem{Text="Popular",Value="Popular"},
                new SelectListItem{Text="Featured",Value="Featured"}
            }, "Value", "Text", product.Category);
            return View(product);
        }

        // POST: Products/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Category,Price,Quantity,File")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (product.File != null)
                    {
                        string imageUrl = UploadedFile(product);
                        product.ImageURL = "/ProductImages/" + imageUrl;
                    }
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.list = new SelectList(new List<SelectListItem>
            {
                new SelectListItem{Text="New",Value="New"},
                new SelectListItem{Text="Popular",Value="Popular"},
                new SelectListItem{Text="Featured",Value="Featured"}
            }, "Value", "Text", product.Category);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'IdentityContext.Products'  is null.");
            }
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
          return (_context.Products?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
