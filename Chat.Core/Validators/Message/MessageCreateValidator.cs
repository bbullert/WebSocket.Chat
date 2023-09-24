using Chat.Core.Dto;
using FluentValidation;

namespace Chat.Core.Validators
{
    public class MessageCreateValidator : AbstractValidator<MessageCreate>
    {
        public MessageCreateValidator()
        {
            RuleFor(x => x.Content)
                .NotEmpty()
                .WithMessage(ValidationErrorMessage.Required)
                .MaximumLength(500)
                .WithMessage(ValidationErrorMessage.MaxLength);

            RuleFor(x => x.CreateDate)
                .NotEmpty()
                .WithMessage(ValidationErrorMessage.Required);

            RuleFor(x => x.ChatId)
                .NotEmpty()
                .WithMessage(ValidationErrorMessage.Required);

            RuleFor(x => x.UserId)
                .NotEmpty()
                .WithMessage(ValidationErrorMessage.Required);
        }
    }
}
