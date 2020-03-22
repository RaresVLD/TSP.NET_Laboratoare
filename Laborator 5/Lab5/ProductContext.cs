using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Lab5
{
    public class ProductContext : DbContext
    {
        public DbSet<Product> Product { get; set; }
        public ProductContext() :
            base("name=ProductContext")
        { }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>()
                .Map(m => {
                    m.Properties(p => new { p.SKU, p.Description, p.Price });
                    m.ToTable("Product", "BazaDeDate");
                }).Map(m => { m.Properties(p => new { p.SKU, p.ImageURL }); m.ToTable("ProductWebInfo", "BazaDeDate"); });
        }
    }
}
