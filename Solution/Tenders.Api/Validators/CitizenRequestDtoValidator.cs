using System;
using FluentValidation;
using Tenders.Core.DTOs;
using Tenders.Core.Enums;

namespace Tenders.Api.Validators
{
    public class CitizenRequestDtoValidator : AbstractValidator<CitizenRequestDto>
    {
        public CitizenRequestDtoValidator()
        {
            RuleFor(i => i.SurName).NotNull()
                .WithState(i => ErrorCodeEnum.FieldIsEmpty)
                .WithMessage(i => "Поле '{PropertyName}' не может быть пустым");

            RuleFor(i => i.FirstName).NotNull()
                .WithState(i => ErrorCodeEnum.FieldIsEmpty)
                .WithMessage(i => "Поле '{PropertyName}' не может быть пустым");

            RuleFor(i => i.Inn).NotNull()
                .WithState(i => ErrorCodeEnum.FieldIsEmpty)
                .WithMessage(i => "Поле '{PropertyName}' не может быть пустым");

            RuleFor(c => c.Snils).NotNull()
                .WithState(i => ErrorCodeEnum.FieldIsEmpty)
                .WithMessage(i => "Поле '{PropertyName}' не может быть пустым");

            RuleFor(c => c.DateOfBirth).LessThanOrEqualTo(p => DateTime.Now)
                .WithState(p => ErrorCodeEnum.InvalidValue)
                .WithMessage(p => "Значение поля '{PropertyName}' не может быть больше текущего дня");

            RuleFor(c => c.DateOfBirth).LessThanOrEqualTo(p => DateTime.Now)
                .WithState(p => ErrorCodeEnum.InvalidValue)
                .WithMessage(p => "Значение поля '{PropertyName}' не может быть больше текущего дня");
        }
    }
}