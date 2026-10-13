using CinemaApp.Data.Common;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static CinemaApp.Data.Common.EntityValidation.Movie;

namespace CinemaApp.Data.Models
{
    [Comment("Movie in the system")]
    public class Movie
    {
        [Comment("Movie Identifier")]
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Comment("Movie Title")]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Comment("Movie Genre")]
        [Required]
        [MaxLength(GenreMaxLength)]
        public string Genre { get; set; } = null!;

        [Comment("Movie Release Date")]
        [Required]
        public DateTime ReleaseDate { get; set; }

        [Comment("Movie Director")]
        [Required]
        [MaxLength(DirectorMaxLength)]
        public string Director { get; set; } = null!;

        public int Duration { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        [MaxLength(ImageUrlMaxLength)]
        public string? ImageUrl { get; set; }

        public bool IsDeleted { get; set; } = false;

        //public virtual ICollection<CinemaMovie> MovieCinemas { get; set; } 
        //    = new HashSet<CinemaMovie>();

        //public virtual ICollection<ApplicationUserMovie> MovieApplicationUsers { get; set; }
        //    = new HashSet<ApplicationUserMovie>();

        //public virtual ICollection<Ticket> Tickets { get; set; }
        //    = new HashSet<Ticket>();
    }
}