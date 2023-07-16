using Business.Abstract.IServices;
using Business.Concrete.Services;
using DataAccess.Abstract.IDal.ClassIDal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Linq;
using AdminIndexViewModel = ECommerceWebUI.Models.ViewModels.AdminViewModels.ViewModel.AdminIndexViewModel;

namespace ECommerceWebUI.ViewComponents
{
	public class SatisBadgeViewComponent:ViewComponent
	{
		private readonly ISatısServices satısServices;

		public SatisBadgeViewComponent(ISatısServices satısServices)
		{
			this.satısServices = satısServices;
		}

		public ViewViewComponentResult Invoke()
		{
			var model = new AdminIndexViewModel
			{
				OrderCount = satısServices.GetAll().Where(x => x.SiparisDurumID!=5 && x.SiparisDurumID!=3).Count(),

			};
			return View(model);
		}
	}
}
