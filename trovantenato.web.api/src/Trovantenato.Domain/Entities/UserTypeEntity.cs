using Trovantenato.Domain.Common;

namespace Trovantenato.Domain.Entities
{
    public class UserTypeEntity : AuditableEntity
    {
        public string? UserTypeName { get; set; }
    }
}
