using LaFiesta.Data;
using LaFiesta.Models;
using LaFiesta.ViewModels;
using LaFiesta.ViewModels.Detail;
using LaFiesta.ViewModels.Lists;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LaFiesta.Controllers
{
    public class FestivalController : Controller
    {
        private readonly LaFiestaContext _context;

        public FestivalController(LaFiestaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ListFestivalViewModel vm = new ListFestivalViewModel()
            {
                Festivals = _context.Festivals.ToList()
            };

            return View(vm);
        }

        public IActionResult Details(int id)
        {
            Festival festival = _context.Festivals.Where(f => f.Id == id).FirstOrDefault();

            DetailFestivalViewModel vm = new DetailFestivalViewModel()
            {
                Naam = festival.Naam,
                Omschrijving = festival.Omschrijving,
                BeginDatum = festival.BeginDatum,
                EindDatum = festival.EindDatum,
                MinimumLeeftijd = festival.MinimumLeeftijd,
                Afbeelding = festival.Afbeelding
            };

            return View(vm);
        }
    }
}
