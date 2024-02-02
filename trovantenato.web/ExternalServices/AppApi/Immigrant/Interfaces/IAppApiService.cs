using Trovantenato.Web.ExternalServices.AppApi.Immigrant.Models.Request;
using Trovantenato.Web.ExternalServices.AppApi.Immigrant.Models.Response;

namespace Trovantenato.Web.ExternalServices.AppApi.Immigrant.Interfaces
{
    public interface IAppApiService
    {
        Task<GetImmigrantsBySurnameResponse> GetImmigrantsBySurname(GetImmigrantsBySurnameRequest request);
    }
}
