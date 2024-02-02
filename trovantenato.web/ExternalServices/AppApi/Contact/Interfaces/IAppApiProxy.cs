using Trovantenato.Web.ExternalServices.AppApi.Contact.Models.Request;

namespace Trovantenato.Web.ExternalServices.AppApi.Contact.Interfaces
{
    public interface IAppApiProxy
    {
        Task<HttpResponseMessage> CreateContact(CreateContactRequest request);
    }
}
