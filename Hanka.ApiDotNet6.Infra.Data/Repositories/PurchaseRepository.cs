using Hanka.ApiDotNet6.Domain;
using Hanka.ApiDotNet6.Domain.Entities;
using Hanka.ApiDotNet6.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Hanka.ApiDotNet6.Infra.Data.Repositories

{
  public class PurchaseRepository : IPurchaseRepository
  {
    private readonly ApplicationDbContext _db;
    public PurchaseRepository(ApplicationDbContext db)
    {
      _db = db;
    }

    public async Task<Purchase> CreateAsync(Purchase purchase)
    {
      _db.Add(purchase);
      await _db.SaveChangesAsync();
      return purchase;
    }

    public async Task DeleteAsync(Purchase purchase)
    {
      _db.Remove(purchase);
      await _db.SaveChangesAsync();
    }

    public async Task EditAsync(Purchase purchase)
    {
      _db.Update(purchase);
      await _db.SaveChangesAsync();
    }

    public async Task<Purchase> GetByIdAsync(int id) => await _db.Purchases.FirstOrDefaultAsync(x => x.Id == id);

    // public async Task<int> GetIdByCodErpAsync(string codeErp)
    // {
    //   return (await _db.Purchases.FirstOrDefaultAsync(x => x.CodeErp == codeErp))?.Id ?? 0;
    // }

    public async Task<ICollection<Purchase>> GetPurchasesAsync() => await _db.Purchases.ToListAsync();
  }
}
