using AutoMapper;
using Hanka.ApiDotNet6.Application.DTOs;
using Hanka.ApiDotNet6.Domain.Entities;

namespace Hanka.ApiDotNet6.Application.Mappings;

public class DomainToDtoMapping : Profile
{
  public DomainToDtoMapping()
  {
    CreateMap<Person, PersonDTO>();
  }
}
