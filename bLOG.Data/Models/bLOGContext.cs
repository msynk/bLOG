using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using bLOG.Data.Models.Mapping;

namespace bLOG.Data.Models
{
    public partial class bLOGContext : DbContext
    {
        static bLOGContext()
        {
            Database.SetInitializer<bLOGContext>(null);
        }

        public bLOGContext()
            : base("Name=bLOGContext")
        {
        }

        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PostMap());
        }
    }
}
