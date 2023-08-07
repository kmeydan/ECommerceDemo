using DataAccess.Entities.Nwind;
using System;
using System.Collections.Generic;

namespace ECommerceWebUI.Models.ViewModels.AdminViewModels.ViewModel.Orders
{
	public class ShipmentViewModel
	{
		public List<string> TeslimatDurumu { get; set; }
		public List<Satis> Satislar { get; set; }
	}
	
}
