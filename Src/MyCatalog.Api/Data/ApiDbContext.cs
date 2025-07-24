using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyCatalog.Api.Models;

namespace MyCatalog.Api.Data
{
    public class ApiDbContext(DbContextOptions<ApiDbContext> options) : IdentityDbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ProdutoModel>().ToTable("Produtos");
        }

        public DbSet<ProdutoModel> Produtos { get; set; } = null!;
    }
}
