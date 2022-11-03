using Hanka.ApiDotNet6.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hanka.ApiDotNet6.Infra.Data.Context
{
  public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    { }

    /* maper entidades e informar que a mesma será uma tabela */
    public DbSet<Person> People { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Purchase> Purchases { get; set; }

    /* Sobrescrever o método para aplicar as configurações dessa classe*/
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
      modelBuilder.ApplyConfigurationsFromAssembly(typeof (ApplicationDbContext).Assembly);
    }
  }
}
