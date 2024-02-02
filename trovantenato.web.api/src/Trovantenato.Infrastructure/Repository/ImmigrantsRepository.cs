using Trovantenato.Domain.Entities;
using Trovantenato.Domain.Interfaces.Repository;
using Trovantenato.Infrastructure.Common;
using Trovantenato.Infrastructure.Context;

namespace Trovantenato.Infrastructure.Repository
{
    public class ImmigrantsRepository : BaseRepository<ImmigrantsEntity>, IImmigrantsRepository
    {
        public ImmigrantsRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}