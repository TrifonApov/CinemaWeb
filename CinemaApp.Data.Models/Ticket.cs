namespace CinemaApp.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Ticket
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public int Quantity { get; set; }

        [ForeignKey(nameof(Projection))]
        public Guid ProjectionId { get; set; }

        public virtual Projection? Projection { get; set; }

        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }

        public virtual ApplicationUser User { get; set; } = null!;
    }
}
