using SocialWebApp.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace SocialWebApp.DAL
{
    public class RelationContext : DbContext    
    {
        public RelationContext() : base("RelationContext")
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<RelationshipType> RelationshipTypes { get; set; }
        public DbSet<Related> Relateds { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }

    }
}