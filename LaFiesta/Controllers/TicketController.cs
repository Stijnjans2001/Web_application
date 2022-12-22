using LaFiesta.Areas.Identity.Data;
using LaFiesta.Data;
using LaFiesta.Models;
using LaFiesta.ViewModels;
using LaFiesta.ViewModels.Create;
using LaFiesta.ViewModels.Delete;
using LaFiesta.ViewModels.Detail;
using LaFiesta.ViewModels.Edit;
using LaFiesta.ViewModels.Lists;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace LaFiesta.Controllers
{
    public class TicketController : Controller
    {
        #region Maken context en index initialiseren
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
        #endregion

        #region Create
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            return View();
        }

		[Authorize(Roles = "admin")]
		[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateTicketViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(new Ticket()
                {
                    Soort = viewModel.Soort,
                    Prijs = viewModel.Prijs,
                    Datum = viewModel.Datum,
                    Aantal = viewModel.Aantal,
                    CustomUserId = "0debe25f-bbef-44f9-b0d6-e85de6da672d"
                });

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }
        #endregion

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

        #region Edit
        [Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();

            Ticket ticket = _context.Tickets.Where(d => d.Id == id).FirstOrDefault();
            if (ticket == null)
                return NotFound();

            EditTicketViewModel vm = new EditTicketViewModel()
            {
                Id = ticket.Id,
                Datum = ticket.Datum,
                Soort = ticket.Soort,
                Prijs = ticket.Prijs,
                Aantal = ticket.Aantal
            };

            return View(vm);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditTicketViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Ticket ticket = new Ticket()
                    {
                        Id = viewModel.Id,
                        Datum = viewModel.Datum,
                        Soort = viewModel.Soort,
                        Prijs = viewModel.Prijs,
                        Aantal = viewModel.Aantal,
                        CustomUserId = "0debe25f-bbef-44f9-b0d6-e85de6da672d"
                    };
                    _context.Update(ticket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException e)
                {
                    if (!_context.Tickets.Any(d => d.Id == viewModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(viewModel);
        } 
        #endregion

        #region Delete
        [Authorize(Roles = "admin")]
		public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Ticket ticket = await _context.Tickets.FirstOrDefaultAsync(u => u.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }

            DeleteTicketViewModel viewModel = new DeleteTicketViewModel()
            {
                Id = ticket.Id,
                Datum = ticket.Datum,
                Soort = ticket.Soort,
                Aantal = ticket.Aantal,
                Prijs = ticket.Prijs,
            };
            return View(viewModel);
        }

		[Authorize(Roles = "admin")]
		[HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            Ticket ticket = await _context.Tickets.FindAsync(id);
            if (ticket != null)
            {
                _context.Tickets.Remove(ticket);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Ticket Not Found");
            }
            return View("Index", _context.Tickets.ToList());
        } 
        #endregion
    }
}
