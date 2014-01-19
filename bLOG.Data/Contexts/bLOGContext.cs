using System.Data.Entity;
using bLOG.Data.Mappings;
using bLOG.Models;

namespace bLOG.Data.Contexts
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
