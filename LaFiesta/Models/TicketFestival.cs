using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace LaFiesta.Models
{
    [Table("TicketFestivals")]
    public class TicketFestival
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        [ForeignKey("Festival")]
        public int FestivalId { get; set; }
        
        [Required]
        [ForeignKey("Ticket")]
        public int TicketId { get; set; }
        
        [Required]
        public Festival Festival { get; set; }
        
        [Required]
        public Ticket Ticket { get; set; }
    }
}
