namespace CinemaApp.Data.Configuration
{
    using CinemaApp.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
                    Id = new Guid("344378CB-CC6C-446D-A513-E2C1B557BE55"),
                    Name = "Odeon",
                    Location = "Sofia",
                    IsDeleted = false
                },
                new()
                {
                    Id = new Guid("1F904122-F663-4054-A2E1-593F06E1B43E"),
                    Name = "House of Cinema",
                    Location = "Sofia",
                    IsDeleted = false
                },
                new()
                {
                    Id = new Guid("E481AB5C-07F7-4C1C-A5EB-1307E757E6C6"),
                    Name = "Arena Burgas",
                    Location = "Burgas",
                    IsDeleted = false
                },
                new()
                {
                    Id = new Guid("0B759211-0E62-49FC-BB13-2F0AED97F859"),
                    Name = "Arena Ruse",
                    Location = "Ruse",
                    IsDeleted = false
                },
                new()
                {
                    Id = new Guid("2887E121-180C-4DA4-A46E-764E8F02441C"),
                    Name = "Cinema City Sofia",
                    Location = "Sofia",
                    IsDeleted = false
                },
                new()
                {
                    Id = new Guid("28E27378-6D13-484A-9652-E55B0C3D1D66"),
                    Name = "Cinema City Plovdiv",
                    Location = "Plovdiv",
                    IsDeleted = false
                },
                new()
                {
                    Id = new Guid("C2E6C95C-A588-4CD8-8F7F-D11E7D6DB49E"),
                    Name = "Cinema City Varna",
                    Location = "Varna",
                    IsDeleted = false
                }
            };
        }
    }
}
