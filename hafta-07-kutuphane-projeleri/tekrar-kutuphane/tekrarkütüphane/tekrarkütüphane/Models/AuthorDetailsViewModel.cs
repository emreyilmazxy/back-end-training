using System.ComponentModel.DataAnnotations;

namespace tekrarkütüphane.Models
{
    public class AuthorDetailsViewModel
    {
        public int Id { get; set; }
        [MaxLength(60)]
        [Required(ErrorMessage = "ad gerekli")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "soy ad gerekli")]
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public List<Book> Books { get; set; }
    }
}
