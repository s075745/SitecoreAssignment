using Microsoft.EntityFrameworkCore;
using SitecoreAssignmentAPI.Models.Domain;

namespace SitecoreAssignmentAPI.Data
{
    public class WalksDbContext:DbContext
    {

        // Later on we want to send our own connection through programe.cs that why usign DbContectOptions
        public WalksDbContext(DbContextOptions dbContextOptions): base(dbContextOptions) 
        { 
        
        }

        // A Dbset is a property of DbContext class represent a collection of entities in the database (Difficulty, Region and walk)
        // We have to repesent the DbSet as a collection of the entity  
        // Below properties represent collection inside our database
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }

    }
}
