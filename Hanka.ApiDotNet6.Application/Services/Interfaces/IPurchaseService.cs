using Hanka.ApiDotNet6.Application.DTOs;

namespace Hanka.ApiDotNet6.Application.Services.Interfaces;

public interface IPurchaseService
{
  Task<ResultService<PurchaseDTO>> CreateAsync(PurchaseDTO purchaseDTO);
}
