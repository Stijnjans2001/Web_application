using LaFiesta.Models;
using System.Collections.Generic;

namespace LaFiesta.ViewModels.Create
{
    public class CreateTicketFestivalViewModel
    {
		public ICollection<Ticket> Tickets { get; set; }
		public int TicketId { get; set; }
		public ICollection<Festival> Festivals { get; set; }
		public int FestivalId { get; set; }
    }
}
