using KJBrainDeveloperService.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace KJBrainDeveloperService.Persistence
{

    /// <summary>
    /// TrainingStatistics datatable configuration class
    /// </summary>
    public class TrainingStatisticsConfiguration : IEntityTypeConfiguration<TrainingStatistics>
    {
        /// <summary>
        /// TrainingStatistics configuration
        /// </summary>
        public void Configure(EntityTypeBuilder<TrainingStatistics> builder)
        {
            builder.ToTable("TrainingStatistics");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                  .ValueGeneratedOnAdd()
                  .IsRequired();


            builder.Property(u => u.Score)
                   .IsRequired();

            builder.Property(u => u.TrainingMode)
                   .IsRequired()
                   .HasDefaultValue(TrainingModeType.MemorySound)
                   .HasConversion(new EnumToStringConverter<TrainingModeType>());

            builder.Property(u => u.Created)
                   .IsRequired();

            builder.HasOne(x => x.User)
             .WithMany(x => x.TrainingStatistics)
             .HasForeignKey(c => c.UserId)
             .HasConstraintName("FK_TrainingStatistics_UserID")
             .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
