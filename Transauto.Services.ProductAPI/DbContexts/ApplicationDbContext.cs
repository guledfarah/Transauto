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
    }
}