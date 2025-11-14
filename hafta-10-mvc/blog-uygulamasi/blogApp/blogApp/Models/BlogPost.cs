using System.ComponentModel.DataAnnotations;

namespace blogApp.Models
{
    public class BlogPost
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="başlık gereklidir")]
        [StringLength(100,ErrorMessage ="100 karakterden uzun olamaz")]
        public string Title { get; set; }

        [Required(ErrorMessage = "içerik gereklidir gereklidir")]
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
