using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace bLOG.Data.Models.Mapping
{
    public class CommentMap : EntityTypeConfiguration<Comment>
    {
        public CommentMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Author)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.Email)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Website)
                .HasMaxLength(200);

            this.Property(t => t.Ip)
                .HasMaxLength(50);

            this.Property(t => t.UserAgent)
                .HasMaxLength(100);

            this.Property(t => t.Content)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Comments");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.PostId).HasColumnName("PostId");
            this.Property(t => t.Author).HasColumnName("Author");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Website).HasColumnName("Website");
            this.Property(t => t.Ip).HasColumnName("Ip");
            this.Property(t => t.UserAgent).HasColumnName("UserAgent");
            this.Property(t => t.Date).HasColumnName("Date");
            this.Property(t => t.Content).HasColumnName("Content");

            // Relationships
            this.HasRequired(t => t.Post)
                .WithMany(t => t.Comments)
                .HasForeignKey(d => d.PostId);

        }
    }
}
