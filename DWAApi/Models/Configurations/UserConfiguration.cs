using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DWAApi.Models.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();
            builder.Property(p => p.Login)
                .IsRequired()
                .ValueGeneratedNever();
            builder.Property(p => p.Password)
                .IsRequired()
                .ValueGeneratedNever();
            builder.Property(p => p.UserInfoId)
                .ValueGeneratedNever();

           // builder.HasOne(e => e.UserInfo)
           //     .WithOne(e => e.User)
           //     .HasForeignKey<User>(p => p.UserInfoId);

        }
    }
}
