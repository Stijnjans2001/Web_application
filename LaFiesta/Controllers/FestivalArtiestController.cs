using LaFiesta.Data;
using LaFiesta.Models;
using LaFiesta.ViewModels.Create;
using LaFiesta.ViewModels.Delete;
using LaFiesta.ViewModels.Lists;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace LaFiesta.Controllers
{
    public class FestivalArtiestController : Controller
    {
        private readonly LaFiestaContext _context;

        public FestivalArtiestController(LaFiestaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ListFestivalArtiestViewModel vm = new ListFestivalArtiestViewModel()
            {
                FestivalArtiesten = _context.FestivalArtiesten
                                            .OrderBy(x => x.Festival.Naam)
                                            .ToList(),
                Festivals = _context.Festivals.ToList(),
                Artiesten = _context.Artiesten.ToList(),
            };
            return View(vm);
        }

        public IActionResult Create()
        {
            CreateFestivalArtiestViewModel vm = new CreateFestivalArtiestViewModel()
            {
                Festivals = _context.Festivals
                                    .OrderBy(x => x.Naam)
                                    .ToList(),
                Artiesten = _context.Artiesten
                                    .OrderBy(x => x.Voornaam)
                                    .ToList(),
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateFestivalArtiestViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(new FestivalArtiest()
                {
                    ArtiestId = viewModel.ArtiestId,
                    FestivalId = viewModel.FestivalId,
                });

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FestivalArtiest festivalArtiest = await _context.FestivalArtiesten.FirstOrDefaultAsync(u => u.Id == id);
            if (festivalArtiest == null)
            {
                return NotFound();
            }

            DeleteFestivalArtiestViewModel viewModel = new DeleteFestivalArtiestViewModel()
            {
                Id = festivalArtiest.Id,
                ArtiestId = festivalArtiest.ArtiestId,
                FestivalId = festivalArtiest.FestivalId
            };
            return View(viewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            FestivalArtiest festivalArtiest = await _context.FestivalArtiesten.FindAsync(id);
            if (festivalArtiest != null)
            {
                _context.FestivalArtiesten.Remove(festivalArtiest);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "FestivalArtiest Not Found");
            }
            return View("Index", _context.FestivalArtiesten.ToList());
        }
    }
}
