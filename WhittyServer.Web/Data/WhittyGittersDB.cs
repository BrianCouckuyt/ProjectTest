using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhittyServer.Web.Entities;

namespace WhittyServer.Web.Data
{
    public class WhittyGittersDbContext : DbContext
    {
        public DbSet<Player> Players { get; set; }

        public WhittyGittersDbContext(DbContextOptions<WhittyGittersDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Player>()
                .HasData(new Player { Id = new Guid("ed596935-fb00-486b-ba11-727270cdfa62"), FirstName = "Jens", LastName = "Deweirdt", IngameName = "TheFirstOfTheWhittens", Email = "jens@whittygitters.be", Password = "thaha" });
        }

    }
}
