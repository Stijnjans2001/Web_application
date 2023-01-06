using LaFiesta.Data;
using LaFiesta.Models;
using LaFiesta.ViewModels.Lists;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LaFiesta.Controllers
{
    public class HomeController : Controller
    {
		private LaFiestaContext _context;

		public HomeController(LaFiestaContext context)
		{
			_context = context;
		}

		public IActionResult Index()
        {
			ListHomeViewModel vm = new ListHomeViewModel()
			{
				Artiesten = _context.Artiesten.ToList(),
				Festivals = _context.Festivals.ToList(),
				Locaties = _context.Locaties.ToList()
			};
			return View(vm);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
