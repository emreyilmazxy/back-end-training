
using System.Text.Json.Serialization;

namespace Survivor.Models
{
    public class CompetitorEntity : BaseEntity
    {
       
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int CategoryId { get; set; }

        // İlişki: Her Competitor bir Category'e aittir
        
        public CategoryEntity? Category { get; set; }

       
    }
}
