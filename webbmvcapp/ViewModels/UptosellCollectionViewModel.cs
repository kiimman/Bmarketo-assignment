namespace webbmvcapp.ViewModels
{
    public class UptosellCollectionViewModel
    {

        public int Id { get; set; } 

        public string ImageUrl { get; set; } = null!;

        public string Title { get; set; } = null!;

        public decimal Price { get; set; }

        public string TitleRed { get; set; } = null!;

        public string UptoSellTitle { get; set; } = null!;

        public string Ingress { get; set; } = null!;

        public string Text { get; set; } = null!;

        public bool DiscoverMore { get; set; } = false;

    }
}
