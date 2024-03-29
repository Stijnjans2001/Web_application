﻿using System;
using System.ComponentModel.DataAnnotations;

namespace LaFiesta.ViewModels.Detail
{
    public class DetailTicketViewModel
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime Datum { get; set; }

        public string Soort { get; set; }

        public decimal Prijs { get; set; }

        public int Aantal { get; set; }
    }
}
