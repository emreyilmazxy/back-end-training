namespace Survivor.Models
{
    public class CategoryEntity : BaseEntity
    {
       

        public string Name { get; set; }

        // İlişki: Her Competitor bir Category'e aittir
        public ICollection<CompetitorEntity> ExistingCompetitors { get; set; } = new List<CompetitorEntity>();

    }
}
