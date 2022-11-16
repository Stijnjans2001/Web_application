using System;
using System.ComponentModel.DataAnnotations;

namespace LaFiesta.ViewModels.Create
{
    public class CreateTicketViewModel
    {
        [DataType(DataType.Date)]
        public DateTime Datum { get; set; }

        public string Soort { get; set; }

        public decimal Prijs { get; set; }

        public int Aantal { get; set; }
    }
}
