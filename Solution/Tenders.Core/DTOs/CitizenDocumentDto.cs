namespace Tenders.Core.DTOs
{

    public class CitizenDocumentDto
    {

        public int Id { get; set; }

        public int TypeId { get; set; }

        public int CitizenId { get; set; }

        public string Number { get; set; }

        public CitizenDocumentTypeDto CitizenDocumentType { get; set; }

    }

}
