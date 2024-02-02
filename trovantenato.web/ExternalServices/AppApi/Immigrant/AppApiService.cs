using Newtonsoft.Json;
using Trovantenato.Web.ExternalServices.AppApi.Common;
using Trovantenato.Web.ExternalServices.AppApi.Immigrant.Interfaces;
using Trovantenato.Web.ExternalServices.AppApi.Immigrant.Models.Request;
using Trovantenato.Web.ExternalServices.AppApi.Immigrant.Models.Response;

namespace Trovantenato.Web.ExternalServices.AppApi.Immigrant
{
    public class AppApiService : IAppApiService
    {
        private readonly IAppApiProxy _appApiProxy;

        public AppApiService(
            IAppApiProxy appApiProxy)
        {
            _appApiProxy = appApiProxy;
        }

        public async Task<GetImmigrantsBySurnameResponse> GetImmigrantsBySurname(GetImmigrantsBySurnameRequest request)
        {
            var response = await _appApiProxy.GetImmigrantsBySurname(request);
            var content = response?.Content.ReadAsStringAsync().Result;

            AppApiMethods.ResponseService(response, content, false);
            return JsonConvert.DeserializeObject<GetImmigrantsBySurnameResponse>(content);
        }
    }
}
