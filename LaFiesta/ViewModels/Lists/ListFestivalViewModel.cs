using LaFiesta.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LaFiesta.ViewModels.Lists
{
    public class ListFestivalViewModel
    {
        public string FestivalSearch { get; set; }
        public ICollection<Festival> Festivals { get; set; }
        public ICollection<Locatie> Locaties { get; set; }
    }
}
