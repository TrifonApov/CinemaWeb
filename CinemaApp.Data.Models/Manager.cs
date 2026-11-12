namespace CinemaApp.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Manager
    {
        [Key]
        public Guid Id { get; set; }

        public int Level { get; set; }

        public Guid UserId { get; set; }

        public ApplicationUser User { get; set; } = null!;

        public virtual ICollection<Cinema> Cinemas { get; set; }
            = new HashSet<Cinema>();
    }
}
