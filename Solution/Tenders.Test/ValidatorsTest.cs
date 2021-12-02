using System;
using System.Linq;
using System.Threading.Tasks;
using Tenders.Api.Validators;
using Tenders.Core.DTOs;
using Xunit;

namespace Tenders.Test
{
    public class ValidatorsTest
    {
        private readonly InnValidator _innValidator;
        private readonly CitizenRequestDtoValidator _citizenRequestDtoValidator;

        public ValidatorsTest()
        {
            _innValidator = new InnValidator();
            _citizenRequestDtoValidator = new CitizenRequestDtoValidator();
        }


        [Fact]
        public async Task ValidateCitizen()
        {
            var dto = new CitizenRequestDto
            {
                SurName = "SurName",
                FirstName = "FirstNam",
                Patronymic = "",
                DateOfBirth = new DateTime(1980, 1, 1),
                DateOfDeath = null,
                Snils = "121212121",
                Inn = "123456789012"
            };
            var results = await _citizenRequestDtoValidator.ValidateAsync(dto);

            Assert.True(results.IsValid, results.Errors.FirstOrDefault()?.ErrorMessage);
        }

        [Fact]
        public async Task ValidateInn()
        {
            var results = await _innValidator.ValidateAsync("123456789012");

            Assert.True(results.IsValid, results.Errors.FirstOrDefault()?.ErrorMessage);
        }
    }
}