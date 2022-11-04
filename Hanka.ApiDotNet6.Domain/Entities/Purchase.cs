using System;
using Hanka.ApiDotNet6.Domain.Validations;

namespace Hanka.ApiDotNet6.Domain.Entities
{
  public sealed class Purchase
  {
    public int Id { get; private set; }
    public int ProductId { get; private set; }
    public int PersonId { get; private set; }
    public DateTime Date { get; private set; }

    /*
    virtual classes to releationship
    */

    public Person Person { get; set; }

    public Product Product { get; set; }
    public Purchase(int id, int productId, int personId )
    {
      DomainValidationException.When(id < 0, "Id must be informed");
      Id = id;
      Validation(productId, personId);
    }

    private void Validation(int productId, int personId )
    {
      DomainValidationException.When(ProductId < 0, "Product must be informed");
      DomainValidationException.When(PersonId < 0, "Person must be informed");
      // DomainValidationException.When(!date.HasValue, "Purchase date must be informed");

      PersonId = productId;
      ProductId = productId;
      Date = DateTime.Now;
    }
  }
}
