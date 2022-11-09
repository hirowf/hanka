using Hanka.ApiDotNet6.Application.DTOs;
using Hanka.ApiDotNet6.Application.Services;
using Hanka.ApiDotNet6.Application.Services.Interfaces;
using Hanka.ApiDotNet6.Domain.Validations;
using Microsoft.AspNetCore.Mvc;

namespace Hanka.ApiDotNet6.Api.Controllers;

[ApiController]
[Route("api/purchases")]
public class PurchaseController : ControllerBase
{
  private readonly IPurchaseService _purchaseService;

  public PurchaseController(IPurchaseService purchaseService)
  {
    _purchaseService = purchaseService;
  }

  [HttpPost]
  public async Task<ActionResult> PostAsync([FromBody] PurchaseDTO purchaseDTO)
  {
    try
    {
      var result = await _purchaseService.CreateAsync(purchaseDTO);
      if (result.IsSuccess)
        return Ok(result);

      return BadRequest(result);
    }
    catch (DomainValidationException ex)
    {

      var result = ResultService.Fail(ex.Message);
      return BadRequest(result);
    }
  }
}
