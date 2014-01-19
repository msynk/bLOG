using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace bLOG.Data.Models.Mapping
{
    public class PostMap : EntityTypeConfiguration<Post>
    {
        public PostMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Title)
                .IsRequired();

            this.Property(t => t.Content)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Posts");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.PublishDate).HasColumnName("PublishDate");
            this.Property(t => t.Content).HasColumnName("Content");
            this.Property(t => t.IsPublished).HasColumnName("IsPublished");
            this.Property(t => t.ViewsCount).HasColumnName("ViewsCount");
        }
    }
}
