namespace webbmvcapp.ViewModels
{
    public class TopSellingItemViewModel
    {

        public int Id { get; set; }

        public string ImageUrl { get; set; } = null!;

        public string Title { get; set; } = null!;

        public decimal Price { get; set; }


    }
}
