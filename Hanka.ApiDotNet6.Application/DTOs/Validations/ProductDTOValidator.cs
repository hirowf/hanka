using FluentValidation;

namespace Hanka.ApiDotNet6.Application.DTOs.Validations
{
  public class ProductDTOValidator : AbstractValidator<ProductDTO>
  {
    public ProductDTOValidator()
    {
      RuleFor(x => x.CodeErp)
      .NotEmpty()
      .NotNull()
      .WithMessage("CodErp must be informed");

      RuleFor(x => x.Name)
      .NotEmpty()
      .NotNull()
      .WithMessage("Name must be informed");

      RuleFor(x => x.Price)
      .GreaterThan(0)
      .WithMessage("Price must be more than zero");
    }

  }
}
