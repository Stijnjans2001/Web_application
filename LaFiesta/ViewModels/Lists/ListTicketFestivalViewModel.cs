using LaFiesta.Models;
using System.Collections.Generic;

namespace LaFiesta.ViewModels.Lists
{
	public class ListTicketFestivalViewModel
	{
		public List<TicketFestival> TicketFestivals { get; set; }
		public List<Ticket> Tickets { get; set; }
		public List<Festival> Festivals { get; set;}
	}
}
