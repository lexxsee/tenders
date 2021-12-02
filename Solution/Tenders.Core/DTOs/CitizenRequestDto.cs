using System;
using System.Collections.Generic;

namespace Tenders.Core.DTOs
{
    public class CitizenRequestDto
    {

        public string SurName { get; set; }

        public string FirstName { get; set; }

        public string Patronymic { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime? DateOfDeath { get; set; }

        public String Inn { get; set; }

        public String Snils { get; set; }

    }
}