using BookCatalogue.API.Validators.ValidationMessages;
using BookCatalogue.Application.Dto;
using FluentValidation;

namespace BookCatalogue.API.Validators
{
    public class AuthorCreateRequestValidator : AbstractValidator<AuthorCreateRequest>
    {
        public AuthorCreateRequestValidator()
        {
            RuleFor(p => p.AuthorName).NotNull().NotEmpty().WithMessage((ValidationMessageType.AuthorNameEmpty).GetValidationMessage())
                                 .MaximumLength(200).WithMessage((ValidationMessageType.AuthorNameInvalid).GetValidationMessage());

        }
    }

}
