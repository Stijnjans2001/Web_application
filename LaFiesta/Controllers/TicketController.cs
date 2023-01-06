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
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<CustomUser> _userManager;

        public TicketController(LaFiestaContext context, UserManager<CustomUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            ListTicketViewModel vm = new ListTicketViewModel()
            {
                TicketFestivals = _context.TicketFestivals.Include(tf => tf.Ticket).Include(tf => tf.Festival).ToList()
            };

            return View(vm);
        }
        #endregion

        #region Create
        //Admin role cannot be given => authorize does not work.
        //[Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            return View();
        }

        //Admin role cannot be given => authorize does not work.
        //[Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateTicketViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(new Ticket()
                {
                    Soort = viewModel.Soort,
                    Prijs = (decimal)viewModel.Prijs,
                    Datum = viewModel.Datum,
                    Aantal = viewModel.Aantal,
                    CustomUserId = _userManager.GetUserId(HttpContext.User)
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
        //Admin role cannot be given => authorize does not work.
        //[Authorize(Roles = "admin")]
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
                Prijs = (decimal)ticket.Prijs,
                Aantal = ticket.Aantal
            };

            return View(vm);
        }

        //Admin role cannot be given => authorize does not work.
        //[Authorize(Roles = "admin")]
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
                        Prijs = (decimal)viewModel.Prijs,
                        Aantal = viewModel.Aantal,
                        CustomUserId = _userManager.GetUserId(HttpContext.User)
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
        //Admin role cannot be given => authorize does not work.
        //[Authorize(Roles = "admin")]
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

        //Admin role cannot be given => authorize does not work.
        //[Authorize(Roles = "admin")]
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
