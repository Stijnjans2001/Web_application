﻿using LaFiesta.Areas.Identity.Data;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace LaFiesta.Models
{
    [Table("Tickets")]
    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Datum { get; set; }

        [Required]
        public string Soort { get; set; }

        [Required]
        public Decimal Prijs { get; set; }

        [Required]
        public int Aantal { get; set; }

        [Required]
        public ICollection<Ticket> Tickets { get; set; }

        [Required]
        public CustomUser CustomUser { get; set; }
    }
}