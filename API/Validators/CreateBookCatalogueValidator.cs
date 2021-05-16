using BookCatalogue.API.Validators.ValidationMessages;
using BookCatalogue.Application.Command;
using FluentValidation;

namespace BookCatalogue.API.Validators
{
    public class CreateBookCatalogueValidator : AbstractValidator<CreateBookCatalogueCommand>
    {
        public CreateBookCatalogueValidator()
        {
            RuleFor(p => p.Title).NotNull().NotEmpty().WithMessage((ValidationMessageType.BookTitleMissing).GetValidationMessage())
                                 .MaximumLength(200).WithMessage((ValidationMessageType.BookTitleLengthInvalid).GetValidationMessage());
            RuleFor(p => p.ISBN).NotNull().NotEmpty().WithMessage((ValidationMessageType.ISBNEmpty).GetValidationMessage())
                                 .MaximumLength(13).WithMessage((ValidationMessageType.ISBNInvalid).GetValidationMessage());
            RuleFor(p => p.PublicationDate).NotNull().Must(ValidationHelper.BeAValidDate).WithMessage((ValidationMessageType.DateInvalid).GetValidationMessage());
            RuleFor(p => p.Authors.Count).NotNull().NotEqual(0).WithMessage((ValidationMessageType.AuthorsCountEmpty).GetValidationMessage());
            RuleForEach(x => x.Authors).SetValidator(new AuthorCreateRequestValidator());
        }
      
    }
}
