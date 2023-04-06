

using Core.DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CORE
{
    public class MyContext: IdentityDbContext<IdentityUser>
    {
        public MyContext(DbContextOptions options) : base(options) { }
      
        //----------------------
     
        public DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new ProductConfiguration().Configure(modelBuilder.Entity<Product>());

            //-------------
            modelBuilder.MappRelationships();
            base.OnModelCreating(modelBuilder);
        }

     }
}
