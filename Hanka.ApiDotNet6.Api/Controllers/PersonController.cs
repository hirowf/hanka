using Hanka.ApiDotNet6.Application.DTOs;
using Hanka.ApiDotNet6.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hanka.ApiDotNet6.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonController : ControllerBase
{
  private readonly IPersonService _personService;

  public PersonController(IPersonService personService)
  {
    _personService = personService;
  }

  [HttpPost]
  public async Task<ActionResult> Post([FromBody] PersonDTO personDTO)
  {
    var result = await _personService.CreateAsync(personDTO);
    if (result.IsSuccess)
      return Ok(result);

    return BadRequest(result);

  }

}
