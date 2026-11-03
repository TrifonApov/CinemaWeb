using CinemaApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaApp.Data.Configuration
{
    public class ProjectionConfiguration : IEntityTypeConfiguration<Projection>
    {
        public void Configure(EntityTypeBuilder<Projection> entity)
        {
            entity
                .HasIndex(pr => new { pr.CinemaId, pr.MovieId, pr.Showtime }, "IX_CinemaMovie_Mapping_Unique")
                .IsUnique();
            entity.HasQueryFilter(p => p.IsDeleted == false &&
                                       p.Movie.IsDeleted == false &&
                                       p.Cinema.IsDeleted == false);
        }
    }
}
