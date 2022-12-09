using LaFiesta.Models;
using System.Collections.Generic;

namespace LaFiesta.ViewModels.Lists
{
    public class ListHomeViewModel
    {
        public ICollection<Artiest> Artiesten { get; set; }
        public ICollection<Festival> Festivals { get; set; }
        public ICollection<Locatie> Locaties { get; set; }
    }
}
