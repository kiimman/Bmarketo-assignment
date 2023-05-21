namespace webbmvcapp.ViewModels
{
    public class HomeIndexViewModel
    {
        public string Title { get; set; } = "Home";
        public BestCollectionViewModel BestCollection { get; set; } = null!;
      
        public UptosellCollectionViewModel UptoSell { get; internal set; } = null!;

        public TopSellingViewModel TopSelling { get; set; } = null!;
    }
}
