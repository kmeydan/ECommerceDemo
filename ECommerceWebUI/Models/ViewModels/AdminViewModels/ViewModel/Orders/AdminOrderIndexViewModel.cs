﻿using DataAccess.ComplexType;
using DataAccess.Concrete.Dal.ClassDal;
using DataAccess.Entities.Nwind;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace ECommerceWebUI.Models.ViewModels.AdminViewModels.ViewModel.Orders
{
	public class AdminOrderIndexViewModel
	{
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public List<Satis> Satislar { get; set; }
		public List<SelectListItem> SiparisDurumu { get; set; }
		public List<SelectListItem> OdemeTipi { get; set; }
		public SelectListItem OdemeDurumu { get; set; }
		public List<Satis> FiltreliSatis { get; set; }
	}

	
}
