using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaFiesta.Models
{
    [Table("Locaties")]
    public class Locatie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Huisnummer { get; set; }

        [Required]
        public string Straat { get; set; }

        [Required]
        public string Plaats { get; set; }

        [Required]
        public string Postcode { get; set; }

        [Required]
        public ICollection<Festival> Festivals { get; set; }
    }
}
