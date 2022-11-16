using LaFiesta.Data;
using LaFiesta.Models;
using LaFiesta.ViewModels;
using LaFiesta.ViewModels.Detail;
using LaFiesta.ViewModels.Lists;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LaFiesta.Controllers
{
    public class ArtiestController : Controller
    {
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

        public IActionResult Details(int id)
        {
            Artiest artiest = _context.Artiesten.Where(a => a.Id == id).FirstOrDefault();

            DetailArtiestViewModel vm = new DetailArtiestViewModel()
            {
                Voornaam = artiest.Voornaam,
                Achternaam = artiest.Achternaam,
                Geslacht = artiest.Geslacht,
                Geboortedatum = artiest.Geboortedatum,
                Afbeelding = artiest.Afbeelding,
                Genre = artiest.Genre
            };

            return View(vm);
        }
    }
}
