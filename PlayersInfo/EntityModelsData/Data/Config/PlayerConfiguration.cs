using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlayersInfo.EntityModelsData.Models.Entities;

namespace PlayersInfo.EntityModelsData.Data.Config
{
    public class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.DateOfBirth).IsRequired().HasMaxLength(180);
            builder.Property(p => p.PictureUrl).IsRequired();
            builder.HasOne(c => c.CountryInfo).WithMany()
                .HasForeignKey(c => c.CountryId);
            builder.HasOne(g => g.GameInfo).WithMany()
                .HasForeignKey(g => g.GameId);
        }
    }
}