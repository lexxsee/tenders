using System;
using System.Collections.Generic;

namespace Tenders.Core.Entities
{
    public class Citizen {

        public Citizen()
        {
            CitizenDocuments = new List<CitizenDocument>();
        }
        public int Id { get; set; }

        public string SurName { get; set; }

        public string FirstName { get; set; }

        public string Patronymic { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime? DateOfDeath { get; set; }

        public IList<CitizenDocument> CitizenDocuments { get; set; }

    }

}
