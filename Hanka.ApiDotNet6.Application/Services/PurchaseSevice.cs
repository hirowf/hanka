using Hanka.ApiDotNet6.Application.DTOs;
using Hanka.ApiDotNet6.Application.DTOs.Validations;
using Hanka.ApiDotNet6.Application.Services.Interfaces;
using Hanka.ApiDotNet6.Domain;
using Hanka.ApiDotNet6.Domain.Entities;
using Hanka.ApiDotNet6.Domain.Repositories;

namespace Hanka.ApiDotNet6.Application.Services;

public class PurchaseSevice : IPurchaseService
{
  private readonly IProductRepository _productRepository;
  private readonly IPersonRepository _personRepository;
  private readonly IPurchaseRepository _purchaseRepository;

  public PurchaseSevice(IProductRepository productRepository, IPersonRepository personRepository, IPurchaseRepository purchaseRepository)
  {
    _productRepository = productRepository;
    _personRepository = personRepository;
    _purchaseRepository = purchaseRepository;
  } 
  public async Task<ResultService<PurchaseDTO>> CreateAsync(PurchaseDTO purchaseDTO)
  {
    if (purchaseDTO == null)
      return ResultService.Fail<PurchaseDTO>("Object must be informed");
    
    var validate = new PurchaseDTOValidator().Validate(purchaseDTO);
    if (!validate.IsValid)
      return ResultService.RequestError<PurchaseDTO>("Problem with validations", validate);
    
    var productId = await _productRepository.GetIdByCodErpAsync(purchaseDTO.CodeErp);
    var personId = await _personRepository.GetIdByDocumentAsync(purchaseDTO.Document);
    var purchase = new Purchase(productId, personId);
    
    var data = await _purchaseRepository.CreateAsync(purchase);
    purchaseDTO.Id = data.Id;
    return ResultService.OK<PurchaseDTO>(purchaseDTO);
  }
}
