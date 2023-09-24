using Chat.Core.Dto;
using FluentValidation;

namespace Chat.Core.Validators
{
    public class ChatUserCreateValidator : AbstractValidator<ChatUserCreate>
    {
        public ChatUserCreateValidator()
        {
            RuleFor(x => x.ChatId)
                .NotEmpty()
                .WithMessage(ValidationErrorMessage.Required);

            RuleFor(x => x.UserId)
                .NotEmpty()
                .WithMessage(ValidationErrorMessage.Required);
        }
    }
}
