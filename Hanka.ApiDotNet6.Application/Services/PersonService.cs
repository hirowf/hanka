using AutoMapper;
using Hanka.ApiDotNet6.Application.DTOs;
using Hanka.ApiDotNet6.Application.DTOs.Validations;
using Hanka.ApiDotNet6.Application.Services.Interfaces;
using Hanka.ApiDotNet6.Domain.Entities;
using Hanka.ApiDotNet6.Domain.Repositories;

namespace Hanka.ApiDotNet6.Application.Services;

public class PersonService : IPersonService
{
  // injections
  private readonly IPersonRepository _personRepository;
  private readonly IMapper _mapper;

  public PersonService(IPersonRepository personRepository, IMapper mapper)
  {
    _personRepository = personRepository;
    _mapper = mapper;
  }

  public async Task<ResultService<PersonDTO>> CreateAsync(PersonDTO personDTO)
  {
    if (personDTO == null)
      return ResultService.Fail<PersonDTO>("Object must be informed");

    var result = new PersonDTOValidator().Validate(personDTO);
    if (!result.IsValid)
      return ResultService.RequestError<PersonDTO>("Problem encountred", result);

    var person = _mapper.Map<Person>(personDTO);
    var data = await _personRepository.CreateAsync(person);
  
    return ResultService.OK<PersonDTO>(_mapper.Map<PersonDTO>(data));

  }
}
