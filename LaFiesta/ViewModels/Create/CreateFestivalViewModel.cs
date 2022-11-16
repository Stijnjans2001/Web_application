using System;
using System.ComponentModel.DataAnnotations;

namespace LaFiesta.ViewModels.Create
{
    public class CreateFestivalViewModel
    {
        public string Naam { get; set; }

        public string Omschrijving { get; set; }

        [DataType(DataType.Date)]
        public DateTime BeginDatum { get; set; }

        [DataType(DataType.Date)]
        public DateTime EindDatum { get; set; }

        public int MinimumLeeftijd { get; set; }

        public string Afbeelding { get; set; }
    }
}
