using Trovantenato.Domain.Common;

namespace Trovantenato.Domain.Entities
{
    public class ContactsEntity : AuditableEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
