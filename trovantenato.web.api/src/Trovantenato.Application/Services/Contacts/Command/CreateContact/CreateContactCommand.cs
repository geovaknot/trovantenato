using MediatR;

namespace Trovantenato.Application.Services.Contacts.Command.CreateContact
{
    public class CreateContactCommand : IRequest<bool>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
