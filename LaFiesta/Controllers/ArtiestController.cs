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
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace LaFiesta.Controllers
{
    public class ArtiestController : Controller
    {
        #region Initialisatie en Index
        private readonly LaFiestaContext _context;

        public ArtiestController(LaFiestaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ListArtiestViewModel vm = new ListArtiestViewModel()
            {
                Artiesten = _context.Artiesten.ToList()
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
        public async Task<IActionResult> Create(CreateArtiestViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(new Artiest()
                {
                    Voornaam = viewModel.Voornaam,
                    Achternaam = viewModel.Achternaam,
                    Geboortedatum = viewModel.Geboortedatum,
                    Geslacht = viewModel.Geslacht,
                    Genre = viewModel.Genre,
                    Afbeelding = "dummy.jpg",
                });

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }
        #endregion

        #region Edit
        [Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();

            Artiest artiest = _context.Artiesten.Where(d => d.Id == id).FirstOrDefault();

            if (artiest == null)
                return NotFound();

            EditArtiestViewModel vm = new EditArtiestViewModel()
            {
                Id = artiest.Id,
                Afbeelding = artiest.Afbeelding,
                Voornaam = artiest.Voornaam,
                Achternaam = artiest.Achternaam,
                Geslacht = artiest.Geslacht,
                Geboortedatum = artiest.Geboortedatum,
                Genre = artiest.Genre,
            };

            return View(vm);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditArtiestViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Artiest artiest = new Artiest()
                    {
                        Id = viewModel.Id,
                        Afbeelding = viewModel.Afbeelding,
                        Voornaam = viewModel.Voornaam,
                        Achternaam = viewModel.Achternaam,
                        Geslacht = viewModel.Geslacht,
                        Geboortedatum = viewModel.Geboortedatum,
                        Genre = viewModel.Genre,
                    };
                    _context.Update(artiest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException e)
                {
                    if (!_context.Artiesten.Any(d => d.Id == viewModel.Id))
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

            Artiest artiest = await _context.Artiesten.FirstOrDefaultAsync(u => u.Id == id);
            if (artiest == null)
            {
                return NotFound();
            }

            DeleteArtiestViewModel viewModel = new DeleteArtiestViewModel()
            {
                Id = artiest.Id,
                Voornaam = artiest.Voornaam,
                Achternaam = artiest.Achternaam
            };
            return View(viewModel);
        }

		[Authorize(Roles = "admin")]
		[HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            Artiest artiest = await _context.Artiesten.FindAsync(id);
            if (artiest != null)
            {
                _context.Artiesten.Remove(artiest);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Artist Not Found");
            }
            return View("Index", _context.Artiesten.ToList());
        } 
        #endregion
    }
}
