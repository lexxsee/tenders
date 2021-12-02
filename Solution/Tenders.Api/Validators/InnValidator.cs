using System.Linq;
using FluentValidation;

namespace Tenders.Api.Validators
{
    public class InnValidator : AbstractValidator<string>
    {
        private const string IncorrectInnStart = "00";
        private const int PInnLength = 12;

        public InnValidator()
        {
            RuleFor(x => x)
                .NotEmpty();

            RuleFor(x => x)
                .Must(x => x != null && x.All(char.IsDigit))
                .WithMessage("может содержать только цифры");

            RuleFor(x => x)
                .Must(x => x is { Length: PInnLength })
                .WithMessage(_ =>
                    $"длина инн должна быть {PInnLength}");

            RuleFor(x => x)
                .Must(x => x != null && !x.StartsWith(IncorrectInnStart))
                .WithMessage(_ => "не может начинаться с 00");
        }
    }
}