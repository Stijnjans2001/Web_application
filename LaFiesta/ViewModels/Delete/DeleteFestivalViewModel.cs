using LaFiesta.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaFiesta.ViewModels.Delete
{
    public class DeleteFestivalViewModel
    {
        public int Id { get; set; }

        public string Naam { get; set; }

        public string Omschrijving { get; set; }

        [DataType(DataType.Date)]
        public DateTime BeginDatum { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime EindDatum { get; set; }

        public int MinimumLeeftijd { get; set; }

        public string Afbeelding { get; set; }

		public ICollection<Locatie> Locaties { get; set; }
    }
}
