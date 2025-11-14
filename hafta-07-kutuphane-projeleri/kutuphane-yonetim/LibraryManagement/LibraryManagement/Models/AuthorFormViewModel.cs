using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models
{
    public class AuthorFormViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ad zorunludur")]
        [StringLength(50,ErrorMessage ="en fazla 50 karakter girilebilir")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyad zorunludur")]
        [StringLength(50, ErrorMessage = "en fazla 50 karakter girilebilir")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Doğum tarihi zorunludur")]
        [DataType(DataType.Date)]
       
        public DateTime DateOfBirth { get; set; }
    }
}
