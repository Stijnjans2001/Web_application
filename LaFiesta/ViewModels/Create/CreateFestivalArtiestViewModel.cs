using LaFiesta.Models;
using System.Collections.Generic;

namespace LaFiesta.ViewModels.Create
{
    public class CreateFestivalArtiestViewModel
    {
        public int ArtiestId { get; set; }
        public ICollection<Artiest> Artiesten { get; set; }
        public int FestivalId { get; set; }
        public ICollection<Festival> Festivals { get; set; }
    }
}
