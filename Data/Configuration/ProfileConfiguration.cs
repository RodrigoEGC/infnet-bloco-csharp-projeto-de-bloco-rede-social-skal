using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration
{
    public class ProfileConfiguration : IEntityTypeConfiguration<ProfileEntity> 
    { 
      public void Configure(EntityTypeBuilder<ProfileEntity> builder)
        {
            builder
                .HasIndex(x => x.GuidId)
                .IsUnique();
        }
    }

}
