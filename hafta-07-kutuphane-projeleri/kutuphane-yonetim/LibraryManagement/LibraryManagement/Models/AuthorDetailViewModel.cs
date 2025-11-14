namespace LibraryManagement.Models
{
    public class AuthorDetailViewModel
    {
        public string FullName { get; set; }
      
        public DateTime DateOfBirth { get; set; }

        public List<BookSummaryViewModel> Books { get; set; } 


    }

   
}
