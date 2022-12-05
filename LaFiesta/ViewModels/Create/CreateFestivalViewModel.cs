using LaFiesta.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaFiesta.ViewModels.Create
{
    public class CreateFestivalViewModel
    {
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
		public string Afbeelding { get; set; }
        public int LocatieId { get; set; }
		public ICollection<Locatie> Locaties { get; set; }
    }
}
