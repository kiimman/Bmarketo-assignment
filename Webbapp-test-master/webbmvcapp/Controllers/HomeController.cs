using Microsoft.AspNetCore.Mvc;
using webbmvcapp.ViewModels;

namespace webbmvcapp.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {

        var viewModel = new HomeIndexViewModel()
        {
            BestCollection = new BestCollectionViewModel
            {
                Title = "BestCollection",
                Categories = new List<string> { "All", "Bag", "Dress", "Decoratio", "Essentials", "Interior", "Laptop", "Mobile", "Beauty" },
                GridItems = new List<GridCollectionItemViewModel>
                {
                    new GridCollectionItemViewModel { Id = "1", Title = "Apple watch collection", Price = 30, ImageUrl = "images/placeholders/270x295.svg" },
                    new GridCollectionItemViewModel { Id = "2", Title = "Apple watch collection", Price = 40, ImageUrl = "images/placeholders/270x295.svg" },
                    new GridCollectionItemViewModel { Id = "3", Title = "Apple watch collection", Price = 50, ImageUrl = "images/placeholders/270x295.svg" },
                    new GridCollectionItemViewModel { Id = "4", Title = "Apple watch collection", Price = 60, ImageUrl = "images/placeholders/270x295.svg" },
                    new GridCollectionItemViewModel { Id = "5", Title = "Apple watch collection", Price = 70, ImageUrl = "images/placeholders/270x295.svg" },
                    new GridCollectionItemViewModel { Id = "6", Title = "Apple watch collection", Price = 80, ImageUrl = "images/placeholders/270x295.svg" },
                    new GridCollectionItemViewModel { Id = "7", Title = "Apple watch collection", Price = 90, ImageUrl = "images/placeholders/270x295.svg" },
                    new GridCollectionItemViewModel { Id = "8", Title = "Apple watch collection", Price = 20, ImageUrl = "images/placeholders/270x295.svg" }
                }
            },

            UptoSell = new UptosellCollectionViewModel
            {
                Title = "Apple watch collection",
                Price = 30,
                ImageUrl = "images/placeholders/369x310.svg",
                TitleRed = "UP TO SELL",
                UptoSellTitle = "50% OFF",
                Ingress = "Get the Best Price",
                Text = "Get the best daily offer et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren no sea taki",                              
                                                           
            },

            TopSelling = new TopSellingViewModel
            {
                Title = "Top Selling products in this week!",
                Item = new List<TopSellingItemViewModel> { 
                    new TopSellingItemViewModel {Id ="9", Title = "Apple watch collection", Price = 30, ImageUrl = "images/placeholders/270x295.svg" },
                    new TopSellingItemViewModel {Id ="10", Title = "Apple watch collection", Price = 40, ImageUrl = "images/placeholders/270x295.svg" },
                    new TopSellingItemViewModel {Id ="11", Title = "Apple watch collection", Price = 50, ImageUrl = "images/placeholders/270x295.svg" },
                    new TopSellingItemViewModel {Id ="12", Title = "Apple watch collection", Price = 70, ImageUrl = "images/placeholders/270x295.svg" },
                    new TopSellingItemViewModel {Id ="13", Title = "Apple watch collection", Price = 33, ImageUrl = "images/placeholders/270x295.svg" },
                    new TopSellingItemViewModel {Id ="14", Title = "Apple watch collection", Price = 56, ImageUrl = "images/placeholders/270x295.svg" },
                    new TopSellingItemViewModel {Id ="15", Title = "Apple watch collection", Price = 99, ImageUrl = "images/placeholders/270x295.svg" },
                }
            }


        };

        return View(viewModel);
    }
}
