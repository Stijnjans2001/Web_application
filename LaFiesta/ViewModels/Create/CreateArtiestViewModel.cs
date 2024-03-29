﻿using System;
using System.ComponentModel.DataAnnotations;

namespace LaFiesta.ViewModels.Create
{
    public class CreateArtiestViewModel
    {
        public string Voornaam { get; set; }

        public string Achternaam { get; set; }
        
        public string Geslacht { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime Geboortedatum { get; set; }

        public string Afbeelding { get; set; }

        public string Genre { get; set; }
    }
}
