using LaFiesta.Data;
using LaFiesta.Models;
using LaFiesta.ViewModels.Create;
using LaFiesta.ViewModels.Delete;
using LaFiesta.ViewModels.Lists;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace LaFiesta.Controllers
{
	//Admin role cannot be given => authorize does not work.
    //[Authorize(Roles = "admin")]
    public class TicketFestivalController : Controller
	{
        #region Initialisatie en Index
        private readonly LaFiestaContext _context;

        public TicketFestivalController(LaFiestaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ListTicketFestivalViewModel vm = new ListTicketFestivalViewModel()
            {
                Tickets = _context.Tickets.ToList(),
                Festivals = _context.Festivals.ToList(),
                TicketFestivals = _context.TicketFestivals.ToList(),
            };
            return View(vm);
        }
        #endregion

        #region Create
        public IActionResult Create()
        {
            CreateTicketFestivalViewModel vm = new CreateTicketFestivalViewModel()
            {
                Festivals = _context.Festivals
                                    .OrderBy(x => x.Naam)
                                    .ToList(),
                Tickets = _context.Tickets
                                    .OrderBy(x => x.Soort)
                                    .ToList(),
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateTicketFestivalViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(new TicketFestival()
                {
                    TicketId = viewModel.TicketId,
                    FestivalId = viewModel.FestivalId,
                });

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }
        #endregion

        #region Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TicketFestival ticketFestival = await _context.TicketFestivals.FirstOrDefaultAsync(u => u.Id == id);
            if (ticketFestival == null)
            {
                return NotFound();
            }

            DeleteTicketFestivalViewModel viewModel = new DeleteTicketFestivalViewModel()
            {
                Id = ticketFestival.Id,
                TicketId = ticketFestival.TicketId,
                FestivalId = ticketFestival.FestivalId
            };
            return View(viewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            TicketFestival ticketFestival = await _context.TicketFestivals.FindAsync(id);
            if (ticketFestival != null)
            {
                _context.TicketFestivals.Remove(ticketFestival);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "TicketFestival Not Found");
            }
            return View("Index", _context.TicketFestivals.ToList());
        } 
        #endregion
    }
}
