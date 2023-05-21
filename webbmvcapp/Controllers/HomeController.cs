using Microsoft.AspNetCore.Mvc;
using webbmvcapp.Contexts;
using webbmvcapp.Models;
using webbmvcapp.ViewModels;

namespace webbmvcapp.Controllers;

public class HomeController : Controller
{
    private readonly IdentityContext _context;
    public HomeController(IdentityContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        List<Product> products=_context.Products.ToList();
        var viewModel = new HomeIndexViewModel()
        {
            BestCollection = new BestCollectionViewModel
            {
                Title = "Featured Products",
                Categories = new List<string> { "All", "Featured", "New", "Popular"},
                GridItems=products.Where(x=>x.Category=="Featured").Select(x=>new GridCollectionItemViewModel { Id=x.Id,Title=x.Name,Price=x.Price,ImageUrl=x.ImageURL}).ToList()
            },
            UptoSell= products.Where(x => x.Category == "Popular").Select(x => 
            new UptosellCollectionViewModel { Id = x.Id, Title = x.Name, Price = x.Price, ImageUrl = x.ImageURL,TitleRed="UP TO SELL",Ingress = "Get the Best Price",
                Text = x.Description,
            }).FirstOrDefault()
            ,

            TopSelling = new TopSellingViewModel
            {
                Title = "New Products",
                Item = products.Where(x => x.Category == "New").Select(x => new TopSellingItemViewModel { Id = x.Id, Title = x.Name, Price = x.Price, ImageUrl = x.ImageURL }).ToList()
            }


        };

        return View(viewModel);
    }
    public IActionResult ProductDetail(int id = 0)
    {
        Product product = new Product();
        if (id>0)
        {
product = _context.Products.Find(id);
        }
        return View(product);
    }
}
