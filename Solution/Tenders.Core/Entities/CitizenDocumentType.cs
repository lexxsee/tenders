using System.Collections.Generic;

namespace Tenders.Core.Entities
{
    public class CitizenDocumentType {

        public int Id { get; set; }

        public string Name { get; set; }

        public IList<CitizenDocument> CitizenDocuments { get; set; }
        
    }

}
