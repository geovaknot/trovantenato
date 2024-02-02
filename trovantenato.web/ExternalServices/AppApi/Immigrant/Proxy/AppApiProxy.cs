using Microsoft.Extensions.Options;
using Trovantenato.Web.Configurations;
using Trovantenato.Web.ExternalServices.AppApi.Common;
using Trovantenato.Web.ExternalServices.AppApi.Immigrant.Interfaces;
using Trovantenato.Web.ExternalServices.AppApi.Immigrant.Models.Request;

namespace Trovantenato.Web.ExternalServices.AppApi.Immigrant.Proxy
{
    public class AppApiProxy : IAppApiProxy
    {
        private readonly string _urlGetImmigrantBySurname;

        public AppApiProxy(
            IOptions<ApplicationSettings> options)
        {
            _urlGetImmigrantBySurname = options.Value.AppApiSettings.UrlGetImmigrantBySurname;
        }

        public async Task<HttpResponseMessage> GetImmigrantsBySurname(GetImmigrantsBySurnameRequest request)
        {
            return await AppApiMethods.Get(string.Format(_urlGetImmigrantBySurname, request.Surname));
        }
    }
}
