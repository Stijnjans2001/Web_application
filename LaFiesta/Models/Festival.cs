﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaFiesta.Models
{
    [Table("Festivals")]
    public class Festival
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Naam { get; set; }

        [Required]
        public string Omschrijving { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime BeginDatum { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EindDatum { get; set; }

        [Required]
        public int MinimumLeeftijd { get; set; }

        [Required]
        public string Afbeelding { get; set; }

        [Required]
        public ICollection<TicketFestival> TicketFestivals { get; set; }

        [Required]
        public ICollection<FestivalArtiest> FestivalArtiesten { get; set; }

        [Required]
        [ForeignKey("Locatie")]
        public int LocatieId { get; set; }

        [Required]
        public Locatie Locatie { get; set; }
    }
}
