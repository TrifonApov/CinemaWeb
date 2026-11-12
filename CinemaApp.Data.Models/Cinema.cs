namespace CinemaApp.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
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

        [ForeignKey(nameof(Manager))]
        public Guid? ManagerId { get; set; }
        public Manager Manager { get; set; } = null!;
        public virtual ICollection<Projection> Projections { get; set; } 
            = new HashSet<Projection>();
    }
}
