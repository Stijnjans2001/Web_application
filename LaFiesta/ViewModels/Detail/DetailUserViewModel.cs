using System;
using System.ComponentModel.DataAnnotations;

namespace LaFiesta.ViewModels.Detail
{
	public class DetailUserViewModel
	{
		public string Id { get; set; }
		public string Voornaam { get; set; }
		public string Achternaam { get; set; }
		[DataType(DataType.Date)]
		public DateTime Geboortedatum { get; set; }
		public string Geslacht { get; set; }
	}
}
