using Trovantenato.Web.ExternalServices.AppApi.Contact.Models.Request;

namespace Trovantenato.Web.ExternalServices.AppApi.Contact.Interfaces
{
    public interface IAppApiService
    {
        Task<bool> CreateContact(CreateContactRequest request);
    }
}
