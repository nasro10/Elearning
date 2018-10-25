using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    public class BookConfiguration : EntityTypeConfiguration<Book>
    {
        public BookConfiguration()
        {
            //properties configuration
            Property(e => e.Description).HasMaxLength(200).IsOptional();

            //Many to Many configuration
            HasMany(p => p.Users)
            .WithMany(v => v.Books)
            .Map(m =>
            {
                m.ToTable("Providings");   //Table d'association
                m.MapLeftKey("Book");
                m.MapRightKey("User");
            });

            //One To Many
            HasOptional(p => p.Category)   // 0,1..*   //if you need 1..* use HasRequired()
                .WithMany(c => c.Books)
                .HasForeignKey(p => p.CategoryId)
                .WillCascadeOnDelete(false);
        }

    }
}
