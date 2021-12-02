namespace Tenders.Core.Entities
{
    public class CitizenDocument {

        public int Id { get; set; }

        public int TypeId { get; set; }

        public int CitizenId { get; set; }

        public string Number { get; set; }

        public CitizenDocumentType CitizenDocumentType { get; set; }

        public Citizen Citizen { get; set; }

    }

}
