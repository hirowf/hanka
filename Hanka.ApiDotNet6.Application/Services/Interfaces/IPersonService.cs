using Hanka.ApiDotNet6.Application.DTOs;

namespace Hanka.ApiDotNet6.Application.Services.Interfaces;

public interface IPersonService
{
  Task<ResultService<PersonDTO>> CreateAsync(PersonDTO personDTO);
  Task<ResultService<ICollection<PersonDTO>>> GetAsync();
  Task<ResultService<PersonDTO>> GetAsyncById(int id);

}
