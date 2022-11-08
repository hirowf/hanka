using Hanka.ApiDotNet6.Application.DTOs;
using Hanka.ApiDotNet6.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hanka.ApiDotNet6.Api.Controllers;
[Route("api/products")]
[ApiController]
public class ProductController : ControllerBase
{
  private readonly IProductService _productService;

  public ProductController(IProductService productService)
  {
     _productService = productService;
  }

  [HttpPost]
  public async Task<ActionResult> PostAsync([FromBody] ProductDTO productDTO)
  {
    var result = await _productService.CreateAsync(productDTO);
    if (result.IsSuccess)
      return Ok(result);

    return BadRequest(result);
  }

  [HttpGet]
  public async Task<ActionResult> GetAsync()
  {
    var result = await _productService.GetAsync();
    if (result.IsSuccess)
      return Ok(result);

    return BadRequest(result);
  }

  [HttpGet]
  [Route("{id}")]
  public async Task<ActionResult> GetByIdAsync(int id)
  {
    var result = await _productService.GetByIdAsync(id);
    if (result.IsSuccess)
      return Ok(result);

    return BadRequest(result);
  }

  [HttpPut]
  public async Task<ActionResult> UpdateAsync([FromBody] ProductDTO productDTO)
  {
    var result = await _productService.CreateAsync(productDTO);
    if (result.IsSuccess)
      return Ok(result);

    return BadRequest(result);
  }

  [HttpDelete]
  [Route("{id}")]
  public async Task<ActionResult> DeleteAsync(int id)
  {
    var result = await _productService.RemoveAsync(id);
    if (result.IsSuccess)
      return Ok(result);
    
    return BadRequest(result);
  }
}

