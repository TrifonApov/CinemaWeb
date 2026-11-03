using CinemaApp.Data.Models;
using System;
using System.Collections.Generic;
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
            entity.HasData(SeedProjections());
        }

        private IEnumerable<Projection> SeedProjections()
        {
            return new List<Projection>
            {
                new()
                {
                    Id = Guid.Parse("8b7f0e22-2f41-4d73-a033-5f5c8a6b2b01"),
                    CinemaId = Guid.Parse("E481AB5C-07F7-4C1C-A5EB-1307E757E6C6"),
                    MovieId = Guid.Parse("4F7AD974-D137-4C0B-4D4C-08DF2B6832ED"),
                    Showtime = new DateTime(2026, 12, 01, 18, 30, 00),
                    AvailableTickets = 120,
                    TicketPrice = 12.50m,
                    IsDeleted = false
                },
                new()
                {
                    Id = Guid.Parse("8b7f0e22-2f41-4d73-a033-5f5c8a6b2b02"),
                    CinemaId = Guid.Parse("E481AB5C-07F7-4C1C-A5EB-1307E757E6C6"),
                    MovieId = Guid.Parse("AB2C3213-48A7-41EA-9393-45C60EF813E6"),
                    Showtime = new DateTime(2026, 12, 01, 20, 00, 00),
                    AvailableTickets = 95,
                    TicketPrice = 14.00m,
                    IsDeleted = false
                },
                new()
                {
                    Id = Guid.Parse("8b7f0e22-2f41-4d73-a033-5f5c8a6b2b03"),
                    CinemaId = Guid.Parse("28E27378-6D13-484A-9652-E55B0C3D1D66"),
                    MovieId = Guid.Parse("AB2C3213-48A7-41EA-9393-45C60EF813E6"),
                    Showtime = new DateTime(2026, 12, 02, 19, 00, 00),
                    AvailableTickets = 80,
                    TicketPrice = 13.50m,
                    IsDeleted = false
                },
                new()
                {
                    Id = Guid.Parse("8b7f0e22-2f41-4d73-a033-5f5c8a6b2b04"),
                    CinemaId = Guid.Parse("C2E6C95C-A588-4CD8-8F7F-D11E7D6DB49E"),
                    MovieId = Guid.Parse("844D9ABD-104D-41AB-B14A-CE059779AD91"),
                    Showtime = new DateTime(2026, 12, 02, 21, 30, 00),
                    AvailableTickets = 110,
                    TicketPrice = 15.00m,
                    IsDeleted = false
                },
                new()
                {
                    Id = Guid.Parse("8b7f0e22-2f41-4d73-a033-5f5c8a6b2b05"),
                    CinemaId = Guid.Parse("C2E6C95C-A588-4CD8-8F7F-D11E7D6DB49E"),
                    MovieId = Guid.Parse("27AF82A3-0609-423E-854E-FCCDC0FF1E28"),
                    Showtime = new DateTime(2026, 12, 03, 17, 00, 00),
                    AvailableTickets = 75,
                    TicketPrice = 11.00m,
                    IsDeleted = false
                },
                new()
                {
                    Id = Guid.Parse("8b7f0e22-2f41-4d73-a033-5f5c8a6b2b06"),
                    CinemaId = Guid.Parse("1F904122-F663-4054-A2E1-593F06E1B43E"),
                    MovieId = Guid.Parse("16376CC6-B3E0-4BF7-A0E4-9CBD1490522C"),
                    Showtime = new DateTime(2026, 12, 03, 20, 30, 00),
                    AvailableTickets = 100,
                    TicketPrice = 14.50m,
                    IsDeleted = false
                },
                new()
                {
                    Id = Guid.Parse("8b7f0e22-2f41-4d73-a033-5f5c8a6b2b07"),
                    CinemaId = Guid.Parse("1F904122-F663-4054-A2E1-593F06E1B43E"),
                    MovieId = Guid.Parse("777634E2-3BB6-4748-8E91-7A10B70C78AC"),
                    Showtime = new DateTime(2026, 12, 04, 18, 00, 00),
                    AvailableTickets = 90,
                    TicketPrice = 12.00m,
                    IsDeleted = false
                }
            };
        }

    }
}
