using Fantastic3D.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Fantastic3D.Persistence
{
    public class LocalDbContext : DbContext
    {
        public LocalDbContext(DbContextOptions<LocalDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        //public override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    EntityTypeBuilder<User> userCatalog = modelBuilder.Entity<User>().ToTable("User");
        //    userCatalog.HasKey(u => u._id);
        //}
            
    }
}
