using System.ComponentModel.DataAnnotations;

namespace CodeFirstBasic.Models
{
    public class GameEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Platform { get; set; }
        [Range(0.0, 10.0)]
        public decimal Rating { get; set; }
    }
}
