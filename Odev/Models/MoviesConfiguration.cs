using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Odev.Models
{
    public class MoviesConfiguration : IEntityTypeConfiguration<Movies>
    {
        public void Configure(EntityTypeBuilder<Movies> builder)
        {
            builder.HasKey(m => m.ID);
            builder.Property(m=>m.MovieName).HasMaxLength(50).IsRequired();
            builder.Property(m=>m.IsVision).IsRequired();
            builder.Property(m=>m.MovieDescription).HasMaxLength(150);
            builder.HasOne(m=>m.MovieCategory).WithMany(mc=>mc.CategoryMovies).HasForeignKey(m => m.CategoryID);
        }
    }
}
