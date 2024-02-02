using Trovantenato.Application.Common.CustomAttibutes;
using Trovantenato.Application.Common.Mappings;
using Trovantenato.Domain.Entities;

namespace Trovantenato.Application.Services.Immigrant.Queries.GetImmigrants
{
    public class ImmigrantDto : IMapFrom<ImmigrantsEntity>
    {
        public Guid Id { get; set; }
        public string Surname { get; set; }
        public string Source { get; set; }
        public string Province { get; set; }
        public DateTime? Birthday { get; set; }
        public string Paternity { get; set; }
        public string Spouse { get; set; }
        public DateTime? MarriageDate { get; set; }
        public string ArrivalBrazilLocation { get; set; }
        public DateTime? ArrivalBrazilDate { get; set; }

        [Confidential]
        public string Comune { get; set; }

        [Confidential]
        public string Marriage { get; set; }
    }

}
