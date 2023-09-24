using Chat.Core.Dto;
using FluentValidation;

namespace Chat.Core.Validators
{
    public class ChatCreateValidator : AbstractValidator<ChatCreate>
    {
        public ChatCreateValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage(ValidationErrorMessage.Required)
                .MaximumLength(50)
                .WithMessage(ValidationErrorMessage.MaxLength);
        }
    }
}
