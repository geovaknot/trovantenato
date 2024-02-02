using CsvHelper.Configuration.Attributes;

namespace Trovantenato.Application.Services.Immigrant.Queries.GetImmigrants
{
    public class ImmigrantFileDto
    {
        [Index(0)]
        public string Surname { get; set; }

        [Index(1)]
        public string Source { get; set; }

        [Index(2)]
        public string Province { get; set; }

        [Index(3)]
        public string Comune { get; set; }

        [Index(4)]
        public DateTime? Birthday { get; set; }

        [Index(5)]
        public string Paternity { get; set; }

        [Index(6)]
        public string Spouse { get; set; }

        [Index(7)]
        public DateTime? MarriageDate { get; set; }

        [Index(8)]
        public string Marriage { get; set; }

        [Index(9)]
        public string ArrivalBrazilLocation { get; set; }

        [Index(10)]
        public DateTime? ArrivalBrazilDate { get; set; }
    }
}
