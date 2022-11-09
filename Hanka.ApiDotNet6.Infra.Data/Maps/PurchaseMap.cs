using Hanka.ApiDotNet6.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hanka.ApiDotNet6.Infra.Data.Maps
{
  public class PurchaseMap : IEntityTypeConfiguration<Purchase>
  {
    public void Configure(EntityTypeBuilder<Purchase> builder)
    {
      builder.ToTable("compra");
      builder.HasKey(x => x.Id);

      builder.Property(x => x.Id)
        .HasColumnName("idcompra")
        .UseIdentityColumn();

      builder.Property(x => x.PersonId)
        .HasColumnName("idpessoa")
        .UseIdentityColumn();

      builder.Property(x => x.ProductId)
        .HasColumnName("idproduto");

      builder.Property(x => x.Date)
        .HasColumnType("date")
        .HasColumnName("datacompra");

      /*
      Uma compra pode ter uma pessoa
      1 pessoa N compras
      1 produto N compras
      */
      builder.HasOne(x => x.Person)
        .WithMany(x => x.Purchases);

      builder.HasOne(x => x.Product)
      .WithMany(x => x.Purchases);

    }
  }

}

