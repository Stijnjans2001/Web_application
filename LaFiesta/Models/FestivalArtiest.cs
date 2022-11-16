using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaFiesta.Models
{
    [Table("FestivalArtiesten")]
    public class FestivalArtiest
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Festival")]
        public int FestivalId { get; set; }

        [Required]
        [ForeignKey("Artiest")]
        public int ArtiestId { get; set; }

        [Required]
        public Festival Festival { get; set; }

        [Required]
        public Artiest Artiest { get; set; }
    }
}
