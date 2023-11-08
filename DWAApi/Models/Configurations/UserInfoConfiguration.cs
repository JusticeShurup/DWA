using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DWAApi.Models.Configurations
{
    public class UserInfoConfiguration : IEntityTypeConfiguration<UserInfo>
    {
        public void Configure(EntityTypeBuilder<UserInfo> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();
            builder.Property(p => p.Age)
                .IsRequired();
            builder.Property(p => p.SkinColour)
                .IsRequired();
            builder.Property(p => p.EUSizeS)
                .IsRequired();
            builder.Property(p => p.EUSizeT)
                .IsRequired();
            builder.Property(p => p.EUSizeL)
                .IsRequired();
            builder.Property(p => p.CircleHip)
                .IsRequired();
            builder.Property(p => p.CircleCalf)
                .IsRequired();
            builder.Property(p => p.UserId)
                .IsRequired();
            builder.HasOne(e => e.User)
                .WithOne(e => e.UserInfo)
                .HasForeignKey<UserInfo>(e => e.UserId)
                .IsRequired();
        }
    }
}
