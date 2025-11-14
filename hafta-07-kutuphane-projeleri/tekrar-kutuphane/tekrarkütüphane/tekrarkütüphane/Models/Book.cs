using System.ComponentModel.DataAnnotations;

namespace tekrarkütüphane.Models
{
    public class Book
    {
        public int Id { get; set; }
        [MaxLength(60)]
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        public int AuthorId { get; set; }
        public string Genre { get; set; }
        public DateTime PublishDate { get; set; }
        public int ISBN { get; set; }
        public int CopiesAvailable { get; set; }
    }
}
