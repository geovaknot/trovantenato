using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Trovantenato.Domain.Common;
using Trovantenato.Domain.Entities;

namespace Trovantenato.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options
            , IHttpContextAccessor httpContextAccessor)
            : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public DbSet<UserEntity> User { get; set; }
        public DbSet<UserTypeEntity> UserType { get; set; }
        public DbSet<ImmigrantsEntity> Immigrants { get; set; }
        public DbSet<ContactsEntity> Contacts { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(c => c.Type == "id")?.Value;
                        entry.Entity.Created = DateTime.Now;
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = _httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(c => c.Type == "id")?.Value;
                        entry.Entity.LastModified = DateTime.Now;
                        break;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // builder
            //.Entity<EventEntity>()
            //.Property(e => e.Ev_Date)
            //.HasConversion<string>();

            base.OnModelCreating(builder);
        }
    }
}
