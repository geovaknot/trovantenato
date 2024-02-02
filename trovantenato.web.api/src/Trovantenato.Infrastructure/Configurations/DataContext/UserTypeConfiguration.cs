using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trovantenato.Domain.Entities;

namespace Trovantenato.Infrastructure.Configurations.DataContext
{
    public class UserTypeConfiguration : IEntityTypeConfiguration<UserTypeEntity>
    {
        public void Configure(EntityTypeBuilder<UserTypeEntity> builder)
        {

            builder.HasKey(p => p.Id);

            builder.Property(d => d.UserTypeName)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.HasData(

                new UserTypeEntity
                {
                    Id = new Guid("ad7db873-a333-4aa3-bafa-2023676cf4cf"),
                    UserTypeName = "Administrador"
                },
                new UserTypeEntity
                {
                    Id = new Guid("9a7c37b7-1de0-4f2e-b8ab-bba8dd2def88"),
                    UserTypeName = "User"
                }
            );

        }
    }
}
