using System;
using Hanka.ApiDotNet6.Domain.Validations;

namespace Hanka.ApiDotNet6.Domain.Entities
{
  public sealed class Product
  {
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string CodeErp { get; private set; }
    public decimal Price { get; private set; }

    public ICollection<Purchase> Purchases { get; set; }
    public Product(string name, string codeErp, decimal price)
    {
      Validation(name, codeErp, price);
      Purchases = new List<Purchase>();
    }

    public Product(int id, string name, string codeErp, decimal price)
    {
      DomainValidationException.When(id < 0, "Id must be more informed");
      Id = id;
      Validation(name, codeErp, price);
      Purchases = new List<Purchase>();
    }
    private void Validation(string name, string codeErp, decimal price)
    {
      DomainValidationException.When(string.IsNullOrEmpty(name), "Name cannot be null");
      DomainValidationException.When(string.IsNullOrEmpty(CodeErp), "CodeErp cannot be null");
      DomainValidationException.When(price < 0, "Price cannot be less than 0");

      Name = name;
      CodeErp = codeErp;
      Price = price;
    }
  }
}
