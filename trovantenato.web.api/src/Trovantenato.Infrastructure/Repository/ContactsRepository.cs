using Trovantenato.Domain.Entities;
using Trovantenato.Domain.Interfaces.Repository;
using Trovantenato.Infrastructure.Common;
using Trovantenato.Infrastructure.Context;

namespace Trovantenato.Infrastructure.Repository
{
    internal class ContactsRepository : BaseRepository<ContactsEntity>, IContactsRepository
    {
        public ContactsRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
