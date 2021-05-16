using BookCatalogue.Application.Dto;
using FluentValidation;
using BookCatalogue.API.Validators.ValidationMessages;

namespace BookCatalogue.API.Validators
{
    public class AuthorDtoValidator : AbstractValidator<AuthorDto>
    {
        public AuthorDtoValidator()
        {
            RuleFor(p => p.AuthorName).NotNull().NotEmpty().WithMessage((ValidationMessageType.AuthorNameEmpty).GetValidationMessage())
                                 .MaximumLength(200).WithMessage((ValidationMessageType.AuthorNameInvalid).GetValidationMessage());
        }
    }
}
