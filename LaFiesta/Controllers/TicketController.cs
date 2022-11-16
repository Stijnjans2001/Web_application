using LaFiesta.Data;
using LaFiesta.Models;
using LaFiesta.ViewModels;
using LaFiesta.ViewModels.Detail;
using LaFiesta.ViewModels.Lists;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LaFiesta.Controllers
{
    public class TicketController : Controller
    {
        private readonly LaFiestaContext _context;

        public TicketController(LaFiestaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ListTicketViewModel vm = new ListTicketViewModel()
            {
                Tickets = _context.Tickets.ToList()
            };

            return View(vm);
        }

        public IActionResult Details(int id)
        {
            Ticket ticket = _context.Tickets.Where(t => t.Id == id).FirstOrDefault();

            DetailTicketViewModel vm = new DetailTicketViewModel()
            {
                Datum = ticket.Datum,
                Soort = ticket.Soort,
                Prijs = ticket.Prijs,
                Aantal = ticket.Aantal
            };

            return View(vm);
        }
    }
}
