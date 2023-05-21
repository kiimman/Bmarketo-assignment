namespace webbmvcapp.ViewModels
{
    public class TopSellingViewModel
    {      

        public string Title { get; set; } = null!;

        public IEnumerable<TopSellingItemViewModel> Item { get; set; } = null!;

    }
}
