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

  public async Task<ResultService> DeleteAsync(int id)
  {
    var person = await _personRepository.GetByIdAsync(id);
    if (person == null)
      return ResultService.Fail("Person not found to remove");

      await _personRepository.DeleteAsync(person);
      return ResultService.OK($"Person with ID: {id} and Name: {person.Name} was removed");
  }

  public async Task<ResultService<ICollection<PersonDTO>>> GetAsync()
  {
    var person= await _personRepository.GetPeopleAsync();
    return ResultService.OK<ICollection<PersonDTO>>(_mapper.Map<ICollection<PersonDTO>>(person));
  }

  public async Task<ResultService<PersonDTO>> GetAsyncById(int id)
  {
    var person = await _personRepository.GetByIdAsync(id);
    if (person == null)
      return ResultService.Fail<PersonDTO>("Person not found");
    return ResultService.OK(_mapper.Map<PersonDTO>(person));
  }

  public async Task<ResultService> UpdateAsync(PersonDTO personDTO)
  {
    if (personDTO == null) 
      return ResultService.Fail("Object must be informed");
      var validation = new PersonDTOValidator().Validate(personDTO);
      if (!validation.IsValid)
        return ResultService.RequestError("Problem with field validations", validation);

        var person = await _personRepository.GetByIdAsync(personDTO.ID);
        if (person == null)
          return ResultService.Fail("Person not found");
        
        // keep the state of person and just update it
        person = _mapper.Map<PersonDTO, Person>(personDTO, person);
        await _personRepository.EditAsync(person);
        return ResultService.OK("Person edited");  
  }
}
