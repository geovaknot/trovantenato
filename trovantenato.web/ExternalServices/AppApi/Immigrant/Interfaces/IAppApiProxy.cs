using Trovantenato.Web.ExternalServices.AppApi.Immigrant.Models.Request;

namespace Trovantenato.Web.ExternalServices.AppApi.Immigrant.Interfaces
{
    public interface IAppApiProxy
    {
        Task<HttpResponseMessage> GetImmigrantsBySurname(GetImmigrantsBySurnameRequest request);
    }
}
