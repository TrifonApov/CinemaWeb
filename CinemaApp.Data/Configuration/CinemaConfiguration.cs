using CinemaApp.Data.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaApp.Data.Configuration
{
    public class CinemaConfiguration : IEntityTypeConfiguration<Cinema>
    {
        public void Configure(EntityTypeBuilder<Cinema> entity)
        {
            entity.HasQueryFilter(c => c.IsDeleted == false);
            entity.HasData(SeedCinemas());
        }

        private IEnumerable<Cinema> SeedCinemas()
        {
            return new List<Cinema>
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Odeon",
                    Location = "Sofia",
                    IsDeleted = false
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "House of Cinema",
                    Location = "Sofia",
                    IsDeleted = false
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Arena Burgas",
                    Location = "Burgas",
                    IsDeleted = false
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Arena Ruse",
                    Location = "Ruse",
                    IsDeleted = false
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Cinema City Sofia",
                    Location = "Sofia",
                    IsDeleted = false
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Cinema City Plovdiv",
                    Location = "Plovdiv",
                    IsDeleted = false
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Cinema City Varna",
                    Location = "Varna",
                    IsDeleted = false
                }
            };
        }
    }
}
