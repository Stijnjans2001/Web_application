using LaFiesta.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LaFiesta.ViewModels.Lists
{
    public class ListLocatieViewModel
    {
        public ICollection<Locatie> Locaties { get; set; }
    }
}
