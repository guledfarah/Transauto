using Microsoft.EntityFrameworkCore;
using Transauto.Services.ProductAPI.Models;

namespace Transauto.Services.ProductAPI.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        #region Public Constructors

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        #endregion Public Constructors

        #region Public Properties

        public DbSet<Product> Products { get; set; }

        #endregion Public Properties

        #region Protected Methods

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 1,
                Name = "Sambusa",
                Price = 12.4,
                Description = "fried triangular shaped pastry with a savory filling like spiced onions, beef meat, and other ingredients",
                CategoryName = "Entree",
                ImageUrl = ""
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 2,
                Name = "Baklava",
                Price = 2.0,
                Description = "a layered pastry dessert made of filo pastry, filled with chopped nuts, and sweetened with syrup or honey",
                CategoryName = "Dessert",
                ImageUrl = ""
            });
        }

        #endregion Protected Methods
    }
}