using Hanka.ApiDotNet6.Domain.Entities;

namespace Hanka.ApiDotNet6.Domain
{
  public interface IPurchaseRepository
  {

    Task<Purchase> CreateAsync(Purchase purchase);
 
  }
}
