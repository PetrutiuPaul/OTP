using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OTP.Models;

namespace OTP.EntityTypeConfiguration
{
    public class UserSecretConfiguration : IEntityTypeConfiguration<UserSecret>
    {
        public void Configure(EntityTypeBuilder<UserSecret> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Secret)
                .IsRequired();

            builder.Property(x => x.Username)
                .IsRequired();
        }
    }
}
