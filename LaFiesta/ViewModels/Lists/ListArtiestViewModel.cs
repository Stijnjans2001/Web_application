using LaFiesta.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LaFiesta.ViewModels.Lists
{
    public class ListArtiestViewModel
    {
        public ICollection<Artiest> Artiesten { get; set; }
    }
}
