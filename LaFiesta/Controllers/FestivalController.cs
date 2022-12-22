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
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaFiesta.Controllers
{
    public class FestivalController : Controller
    {
        #region Initialisatie en Index
        private readonly LaFiestaContext _context;

        public FestivalController(LaFiestaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ListFestivalViewModel vm = new ListFestivalViewModel()
            {
                Festivals = _context.Festivals.ToList(),
                Locaties = _context.Locaties.ToList()
            };

            return View(vm);
        }
		#endregion

		#region Create
		[Authorize(Roles = "admin")]
		public IActionResult Create()
        {
            CreateFestivalViewModel vm = new CreateFestivalViewModel()
            {
                Locaties = _context.Locaties.ToList()
            };
            return View(vm);
        }

		[Authorize(Roles = "admin")]
		[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateFestivalViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(new Festival()
                {
                    Naam = viewModel.Naam,
                    Omschrijving = viewModel.Omschrijving,
                    BeginDatum = viewModel.BeginDatum,
                    EindDatum = viewModel.BeginDatum,
                    MinimumLeeftijd = viewModel.MinimumLeeftijd,
                    LocatieId = viewModel.LocatieId,
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

            Festival festival = _context.Festivals.Where(d => d.Id == id).FirstOrDefault();
            if (festival == null)
                return NotFound();

            EditFestivalViewModel vm = new EditFestivalViewModel()
            {
                Locaties = _context.Locaties.ToList(),
                Id = festival.Id,
                Afbeelding = festival.Afbeelding,
                Naam = festival.Naam,
                Omschrijving = festival.Omschrijving,
                BeginDatum = festival.BeginDatum,
                EindDatum = festival.EindDatum,
                MinimumLeeftijd = festival.MinimumLeeftijd,
                LocatieId = festival.LocatieId,
            };

            return View(vm);
        }

		[Authorize(Roles = "admin")]
		[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditFestivalViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Festival festival = new Festival()
                    {
                        Id = viewModel.Id,
                        Afbeelding = viewModel.Afbeelding,
                        Naam = viewModel.Naam,
                        Omschrijving = viewModel.Omschrijving,
                        BeginDatum = viewModel.BeginDatum,
                        EindDatum = viewModel.EindDatum,
                        MinimumLeeftijd = viewModel.MinimumLeeftijd,
                        LocatieId = viewModel.LocatieId,
                    };
                    _context.Update(festival);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException e)
                {
                    if (!_context.Festivals.Any(d => d.Id == viewModel.Id))
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

        public IActionResult Details(int id)
        {
            ICollection<FestivalArtiest> festaivalArtiesten = _context.FestivalArtiesten.Where(fa => fa.FestivalId == id).Include(a => a.Artiest).ToList();
            Festival festival = _context.Festivals.Where(f => f.Id == id).Include(f => f.Locatie).FirstOrDefault();
            
            if(festival != null)
            {
				DetailFestivalViewModel vm = new DetailFestivalViewModel()
				{
					Naam = festival.Naam,
					Omschrijving = festival.Omschrijving,
					BeginDatum = festival.BeginDatum,
					EindDatum = festival.EindDatum,
					MinimumLeeftijd = festival.MinimumLeeftijd,
					Afbeelding = festival.Afbeelding,
                    Locatie = festival.Locatie,
                    FestivalArtiesten = festival.FestivalArtiesten,
                };
				return View(vm);
			}
            else
            {
				ListFestivalViewModel viewModel = new ListFestivalViewModel()
                {
					Festivals = _context.Festivals.ToList()
				};
				return View("Index", viewModel);
			}           
        }

		#region Delete
		[Authorize(Roles = "admin")]
		public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Festival festival = await _context.Festivals.FirstOrDefaultAsync(u => u.Id == id);
            if (festival == null)
            {
                return NotFound();
            }

            DeleteFestivalViewModel viewModel = new DeleteFestivalViewModel()
            {
                Id = festival.Id,
                Naam = festival.Naam,
                BeginDatum = festival.BeginDatum,
                EindDatum = festival.EindDatum,
            };
            return View(viewModel);
        }

		[Authorize(Roles = "admin")]
		[HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            Festival festival = await _context.Festivals.FindAsync(id);
            if (festival != null)
            {
                _context.Festivals.Remove(festival);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Festival Not Found");
            }
            return View("Index", _context.Festivals.ToList());
        } 
        #endregion
    }
}
