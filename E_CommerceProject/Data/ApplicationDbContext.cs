using E_CommerceProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace E_CommerceProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            

        }
        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder.Entity<Product>()
        //    .Property(e => e.Image)
        //    .HasColumnType("varbinary(max)");
        //}
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
       
    }
}