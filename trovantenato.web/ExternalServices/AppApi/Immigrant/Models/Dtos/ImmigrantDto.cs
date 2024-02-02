namespace Trovantenato.Web.ExternalServices.AppApi.Immigrant.Models.Dtos
{
    public class ImmigrantDto
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
        public string Comune { get; set; }
        public string Marriage { get; set; }
    }
}
