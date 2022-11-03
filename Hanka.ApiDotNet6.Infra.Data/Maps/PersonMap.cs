using Hanka.ApiDotNet6.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Hanka.ApiDotNet6.Infra.Data.Maps
{
  public class PersonMap : IEntityTypeConfiguration<Person>
  {
    public void Configure(EntityTypeBuilder<Person> builder)
    {
      // mapando a tabela e informando a chave
      builder.ToTable("Pessoa");
      builder.HasKey(c => c.Id);
      builder.Property(c => c.Id)
        .HasColumnName("IdPessoa")
        .UseIdentityColumn();
      builder.Property(c => c.Document)
        .HasColumnName("Documento");
      builder.Property(c => c.Name)
        .HasColumnName("Nome");
      builder.Property(c => c.Phone)
        .HasColumnName("Celular");
      builder.HasMany(c => c.Purchases)
        .WithOne(p => p.Person)
        .HasForeignKey(c => c.PersonId);
    }
  }
}

