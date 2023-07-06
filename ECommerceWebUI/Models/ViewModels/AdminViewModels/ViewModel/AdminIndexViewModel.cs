using DataAccess.Entities.Nwind;
using System;
using System.Collections;
using System.Collections.Generic;

namespace ECommerceWebUI.Models.ViewModels.AdminViewModels.ViewModel
{
	public class AdminIndexViewModel
	{
		public int ProductsCount { get; set; }
		public int OrderCount { get; set; }
		public int CustomerCount { get; set; }
		public int OrderAll { get; set; }
		public List<AdminIndexSonSiparis> SonSiparis { get; set; }
		public List<SiparisToplamları> SiparisToplamları { get; set; }
		public ArrayList SiparisAdedi { get; set; }
		public ArrayList SatısTarihi { get; set; }
	}
	public class AdminIndexSonSiparis
	{
		public int SiparisId { get; set; }
		public int SiparisDurumu { get; set; }
		public string Musteri { get; set; }
		public DateTime SiparisTarihi { get; set; }
	}
	public class SiparisToplamları
	{
		public int SiparisDurumu { get; set; }
		public int GunlukSiparisTutarı { get; set; }
		public int HaftalıkSiparisTutarı { get; set; }
		public int AylıkSiparisTutarı { get; set; }
		public int TumZamanlarSiparisTutari { get; set; }
	}
}
