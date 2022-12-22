using LaFiesta.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LaFiesta.ViewModels.Lists
{
    public class ListTicketViewModel
    {
        public List<Ticket> Tickets { get; set; }
        public List<TicketFestival> TicketFestivals { get; set; }
    }
}
