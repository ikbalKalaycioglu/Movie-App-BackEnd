using Core.Entites.Concrete;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Context
{
    public class BitirmeProjesiContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseSqlServer("Server = IKBALS-PC; Database = BitirmeProjesi; Trusted_Connection = True; TrustServerCertificate=True;");
        }

        public DbSet<Content> Contents { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<DirectorImage> DirectorImages { get; set; }
        public DbSet<Poster> Posters { get; set; }
        public DbSet<Star> Stars { get; set; }
        public DbSet<StarImage> starImages { get; set; }
        public DbSet<WatchList> WatchList { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<OperationClaim> OperationClaims { get; set; }

        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
