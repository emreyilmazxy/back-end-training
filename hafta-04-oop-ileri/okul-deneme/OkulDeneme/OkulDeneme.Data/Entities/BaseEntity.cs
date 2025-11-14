using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OkulDeneme.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkulDeneme.Data.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime MotifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }// end of BaseEntity class
}

public abstract class BaseConfigutation<TEntity> where TEntity : BaseEntity
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasQueryFilter(e => e.IsDeleted == false);
        builder.Property(e => e.MotifiedDate)
                .IsRequired(false);
    } // end of Configure method
}