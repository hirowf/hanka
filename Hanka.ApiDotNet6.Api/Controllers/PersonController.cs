using Hanka.ApiDotNet6.Application.DTOs;
using Hanka.ApiDotNet6.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hanka.ApiDotNet6.Api.Controllers;

[ApiController]
[Route("api/persons")]
public class PersonController : ControllerBase
{
  private readonly IPersonService _personService;

  public PersonController(IPersonService personService)
  {
    _personService = personService;
  }

  [HttpPost]
  public async Task<ActionResult> PostAsync([FromBody] PersonDTO personDTO)
  {
    var result = await _personService.CreateAsync(personDTO);
    if (result.IsSuccess)
      return Ok(result);

    return BadRequest(result);

  }

  [HttpGet]
  public async Task<ActionResult<List<PersonDTO>>> GetAsync()
  {
    var result = await _personService.GetAsync();
    if (result.IsSuccess)
    return Ok(result);

    return BadRequest(result);
  }

  [HttpGet]
  [Route("{id}")]
  public async Task<ActionResult> GetByIdAsync(int id)
  {
    var result = await _personService.GetAsyncById(id);
    if (result.IsSuccess)
      return Ok(result);

      return BadRequest(result);

  }

  
  [HttpPut]
  public async Task<ActionResult> UpdateAsync([FromBody] PersonDTO personDTO)
  {
    var result = await _personService.UpdateAsync(personDTO);
    if (result.IsSuccess)
      return Ok(result);

    return BadRequest(result);

  }

    
  [HttpDelete]
  [Route("{id}")]
  public async Task<ActionResult> DeleteAsync(int id)
  {
    var result = await _personService.DeleteAsync(id);
    if (result.IsSuccess)
      return Ok(result);

    return BadRequest(result);

  }

}
