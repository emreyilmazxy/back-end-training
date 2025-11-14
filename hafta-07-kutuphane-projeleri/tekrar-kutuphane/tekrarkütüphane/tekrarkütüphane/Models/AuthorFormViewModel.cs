using System.ComponentModel.DataAnnotations;

namespace tekrarkütüphane.Models
{
    public class AuthorFormViewModel
    {
        public int Id { get; set; }
        [MaxLength(60)]
        [Required(ErrorMessage = "isim gerekli")]
        public string FirstName { get; set; }
        [MaxLength(60)]
        [Required(ErrorMessage = "soy isim gerekli")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "doğum tarihi gerekli")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
    }
}
