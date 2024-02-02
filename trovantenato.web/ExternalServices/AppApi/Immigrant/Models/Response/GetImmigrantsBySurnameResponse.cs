using Trovantenato.Web.ExternalServices.AppApi.Immigrant.Models.Dtos;

namespace Trovantenato.Web.ExternalServices.AppApi.Immigrant.Models.Response
{
    public class GetImmigrantsBySurnameResponse
    {
        public IList<ImmigrantDto> Immigrants { get; set; } = new List<ImmigrantDto>();
    }
}
