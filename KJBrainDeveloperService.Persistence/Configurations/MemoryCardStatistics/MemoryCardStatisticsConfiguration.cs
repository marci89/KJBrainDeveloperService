using KJBrainDeveloperService.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace KJBrainDeveloperService.Persistence
{

    /// <summary>
    /// MemoryCardStatistics datatable configuration class
    /// </summary>
    public class MemoryCardStatisticsConfiguration : IEntityTypeConfiguration<MemoryCardStatistics>
    {
        /// <summary>
        /// MemoryCardStatistics configuration
        /// </summary>
        public void Configure(EntityTypeBuilder<MemoryCardStatistics> builder)
        {
            builder.ToTable("MemoryCardStatistics");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                  .ValueGeneratedOnAdd()
                  .IsRequired();


            builder.Property(u => u.Moved)
                   .IsRequired();

            builder.Property(u => u.LastPictureTypeId)
                   .IsRequired();

            builder.Property(u => u.Difficult)
                   .IsRequired()
                   .HasDefaultValue(DifficultType.Easy)
                   .HasConversion(new EnumToStringConverter<DifficultType>());

            builder.Property(u => u.Created)
                   .IsRequired();

            builder.HasOne(x => x.User)
             .WithMany(x => x.MemoryCardStatistics)
             .HasForeignKey(c => c.UserId)
             .HasConstraintName("FK_MemoryCardStatistics_UserID")
             .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
