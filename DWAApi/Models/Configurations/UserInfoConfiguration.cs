using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DWAApi.Models.Configurations
{
    public class UserInfoConfiguration : IEntityTypeConfiguration<UserInfo>
    {
        public void Configure(EntityTypeBuilder<UserInfo> builder)
        {
            builder.HasKey(p => p.id);
            builder.Property(p => p.id).IsRequired().ValueGeneratedOnAdd();

            
            builder.HasOne(e => e.User)
                .WithOne(e => e.UserInfo);
        }
    }
}
