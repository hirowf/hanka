
using System;
using FluentValidation;

namespace Hanka.ApiDotNet6.Application.DTOs.Validations
{
  public class PersonDTOValidator : AbstractValidator<PersonDTO>
  {
    public PersonDTOValidator()
    {
      RuleFor(x => x.Document)
      .NotEmpty()
      .NotNull()
      .WithMessage("Document must be informed")      
    }
  } 
}
