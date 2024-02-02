using Newtonsoft.Json;
using Trovantenato.Web.ExternalServices.AppApi.Common;
using Trovantenato.Web.ExternalServices.AppApi.Contact.Interfaces;
using Trovantenato.Web.ExternalServices.AppApi.Contact.Models.Request;

namespace Trovantenato.Web.ExternalServices.AppApi.Contact
{
    public class AppApiService : IAppApiService
    {
        private readonly IAppApiProxy _appApiProxy;

        public AppApiService(
            IAppApiProxy appApiProxy)
        {
            _appApiProxy = appApiProxy;
        }

        public async Task<bool> CreateContact(CreateContactRequest request)
        {
            var response = await _appApiProxy.CreateContact(request);
            var content = response?.Content.ReadAsStringAsync().Result;

            AppApiMethods.ResponseService(response, content, false);
            return JsonConvert.DeserializeObject<bool>(content);
        }
    }
}
