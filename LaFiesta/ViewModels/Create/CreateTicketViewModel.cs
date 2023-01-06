using System.ComponentModel.DataAnnotations;
using System;

namespace LaFiesta.ViewModels.Create
{
    public class CreateTicketViewModel
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime Datum { get; set; }

        public string Soort { get; set; }

        public decimal Prijs { get; set; }

        public int Aantal { get; set; }
    }
}
