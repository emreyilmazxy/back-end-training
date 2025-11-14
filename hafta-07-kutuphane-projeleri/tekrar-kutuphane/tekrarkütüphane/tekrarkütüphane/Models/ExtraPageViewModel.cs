namespace tekrarkütüphane.Models
{
    public class ExtraPageViewModel
    {
        public int? SelectedAuthorId { get; set; }
        public List<ExtraViewModel> Authors { get; set; }
        public List<Book> Books { get; set; }
    }
}
