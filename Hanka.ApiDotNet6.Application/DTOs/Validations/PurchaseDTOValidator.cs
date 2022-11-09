using FluentValidation;

namespace Hanka.ApiDotNet6.Application.DTOs.Validations;

public class PurchaseDTOValidator : AbstractValidator<PurchaseDTO>
{ 
  public  PurchaseDTOValidator()
  {
      RuleFor(x => x.CodeErp)
        .NotEmpty()
        .NotNull()
        .WithMessage("CodeErp must be informed");

      RuleFor(x => x.Document)
        .NotEmpty()
        .NotNull()
        .WithMessage("Document must be informed");
  }
}
