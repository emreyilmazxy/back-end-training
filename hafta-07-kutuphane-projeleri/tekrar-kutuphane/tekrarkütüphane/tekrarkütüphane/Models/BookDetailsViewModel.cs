using System.ComponentModel.DataAnnotations;

namespace tekrarkütüphane.Models
{
    public class BookDetailsViewModel
    {
        public int Id { get; set; }
        [MaxLength(60)]
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        public string Genre { get; set; }
        public DateTime PublishDate { get; set; }
       
        public int CopiesAvailable { get; set; }

        public  Author Author { get; set; }
    }
}
