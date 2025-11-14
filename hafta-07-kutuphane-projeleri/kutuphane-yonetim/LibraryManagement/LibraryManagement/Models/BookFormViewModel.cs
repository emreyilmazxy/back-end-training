using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models
{
   public class BookFormViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Kitap adı gereklidir.")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Tür bilgisi gereklidir.")]
    public string Genre { get; set; }

    [Required(ErrorMessage = "Yazar seçilmelidir.")]
    public int AuthorId { get; set; } 
}


}
