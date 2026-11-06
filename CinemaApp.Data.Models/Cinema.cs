namespace CinemaApp.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using CinemaApp.Data.Common;

    public class Cinema
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(EntityValidation.Cinema.NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(EntityValidation.Cinema.LocationMaxLength)]
        public string Location { get; set; } = null!;

        public bool IsDeleted { get; set; } = false;

        public virtual ICollection<Projection> Projections { get; set; } 
            = new HashSet<Projection>();
    }
}
