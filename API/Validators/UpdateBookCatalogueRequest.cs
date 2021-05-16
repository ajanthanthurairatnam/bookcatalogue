using BookCatalogue.API.Validators.ValidationMessages;
using BookCatalogue.Application.Models.Contracts.Requests;
using FluentValidation;

namespace BookCatalogue.API.Validators
{
    public class UpdateBookCatalogueRequestValidator : AbstractValidator<UpdateBookCatalogueRequest>
    {
        public UpdateBookCatalogueRequestValidator()
        {
            RuleFor(p => p.Title).MaximumLength(200).WithMessage((ValidationMessageType.BookTitleLengthInvalid).GetValidationMessage());
            RuleFor(p => p.ISBN).NotNull().MaximumLength(13).WithMessage((ValidationMessageType.ISBNInvalid).GetValidationMessage());
            RuleFor(p => p.PublicationDate).Must(ValidationHelper.BeAValidDate).WithMessage((ValidationMessageType.DateInvalid).GetValidationMessage());
            RuleFor(p => p.Authors.Count).NotNull().NotEqual(0).WithMessage((ValidationMessageType.AuthorsCountEmpty).GetValidationMessage());
            RuleForEach(x => x.Authors).SetValidator(new AuthorDtoValidator());
        }
    }
}
