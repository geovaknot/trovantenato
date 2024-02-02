using Microsoft.Extensions.Options;
using Trovantenato.Web.Configurations;
using Trovantenato.Web.ExternalServices.AppApi.Common;
using Trovantenato.Web.ExternalServices.AppApi.Contact.Interfaces;
using Trovantenato.Web.ExternalServices.AppApi.Contact.Models.Request;

namespace Trovantenato.Web.ExternalServices.AppApi.Contact.Proxy
{
    public class AppApiProxy : IAppApiProxy
    {
        private readonly string _urlCreateContact;

        public AppApiProxy(
            IOptions<ApplicationSettings> options)
        {
            _urlCreateContact = options.Value.AppApiSettings.UrlCreateContact;
        }

        public async Task<HttpResponseMessage> CreateContact(CreateContactRequest request)
        {
            return await AppApiMethods.Post(request, _urlCreateContact);
        }
    }
}
