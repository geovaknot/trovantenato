using Trovantenato.Domain.Common;

namespace Trovantenato.Domain.Entities
{
    public class ImmigrantsEntity : AuditableEntity
    {
        public string Surname { get; set; }
        public string Source { get; set; }
        public string Province { get; set; }
        public string Comune { get; set; }
        public DateTime? Birthday { get; set; }
        public string Paternity { get; set; }
        public string Spouse { get; set; }
        public DateTime? MarriageDate { get; set; }
        public string Marriage { get; set; }
        public string ArrivalBrazilLocation { get; set; }
        public DateTime? ArrivalBrazilDate { get; set; }
    }
}