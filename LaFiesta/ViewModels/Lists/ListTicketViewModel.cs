using LaFiesta.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LaFiesta.ViewModels.Lists
{
    public class ListTicketViewModel
    {
        public ICollection<Ticket> Tickets { get; set; }
    }
}
