using Trovantenato.Domain.Common;

namespace Trovantenato.Domain.Entities
{
    public class UserEntity : AuditableEntity
    {
        public string? UserCpf { get; set; }

        public string? UserName { get; set; }

        public string? Password { get; set; }

        public GenreTypeEnum GenreType { get; set; }

        public string? UserMail { get; set; }

        public string? UserPhone { get; set; }

        public bool TagAcceptTerms { get; set; } = false;

        public bool TagReceiveNews { get; set; } = false;

        public UserTypeEntity? UserType { get; set; }

        public bool? UserExcluded { get; set; }

        public string? IpAddress { get; set; }
    }
}
