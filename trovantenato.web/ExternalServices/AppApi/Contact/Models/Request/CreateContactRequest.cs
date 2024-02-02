namespace Trovantenato.Web.ExternalServices.AppApi.Contact.Models.Request
{
    public class CreateContactRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
