using System;

namespace Tenders.Core.DTOs
{
    public class CitizenFilterDto
    {
        public string SurName { get; set; }

        public string FirstName { get; set; }

        public string Patronymic { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public DateTime? DateOfDeath { get; set; }
    }
}