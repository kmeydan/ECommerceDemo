using Business.Abstract.IServices;
using Business.Concrete.Services;
using DataAccess.Abstract.IDal.ClassIDal;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DestekSınıf.SiparisServicesDestek
{
	public class AdminPageDestek
	{
		private readonly ISatısServices satısServices;

		public AdminPageDestek()
		{
		}

		public AdminPageDestek(ISatısServices satısServices)
		{
			this.satısServices = satısServices;
		}

		public AdminIndexViewModel SiparisToplamları(string durum,int day)
		{
			var gelen = satısServices.IndexSiparisToplamları();
			var tarih = DateTime.Now.AddDays(day);
			var model = new AdminIndexViewModel()
			{
				BirimFiyati=gelen.Where(x => x.SiparisTarihleri >= tarih && x.SiparisTarihleri <= DateTime.Now && x.SiparisDurumu == durum).Select(x=>x.BirimFiyati*x.Miktar).Sum(),
			};

			return model;
		}
	}
}
