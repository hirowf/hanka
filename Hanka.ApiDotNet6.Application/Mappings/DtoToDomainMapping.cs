using AutoMapper;
using Hanka.ApiDotNet6.Application.DTOs;
using Hanka.ApiDotNet6.Domain.Entities;

namespace Hanka.ApiDotNet6.Application.Mappings;

public class DtoToDomainMapping : Profile
{
  public DtoToDomainMapping()
  {
    CreateMap<PersonDTO, Person>();
  }
}
