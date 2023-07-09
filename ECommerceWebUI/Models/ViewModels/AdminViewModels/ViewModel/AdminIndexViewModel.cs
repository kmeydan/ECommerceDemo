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
		public List<AdminSiparisToplamları> SiparisToplamları { get; set; }

		
	}
	public class AdminIndexSonSiparis
	{
		public int SiparisId { get; set; }
		public int SiparisDurumu { get; set; }
		public string Musteri { get; set; }
		public DateTime SiparisTarihi { get; set; }
	}
	public class AdminSiparisToplamları
	{
		public int GunlukSiparisIsleniyor { get; set; }
		public int HaftalıkSiparisIsleniyor { get; set; }
		public int AylıkSiparisIsleniyor { get; set; }
		public int TumZamanlarSiparisIsleniyor { get; set; }
		public int GunlukSiparisHazırlanıyor { get; set; }
		public int HaftalıkSiparisHazırlanıyor { get; set; }
		public int AylıkSiparisHazırlanıyor { get; set; }
		public int TumZamanlarSiparisHazırlanıyor { get; set; }
		public int GunlukSiparisIptal { get; set; }
		public int HaftalıkSiparisIptal { get; set; }
		public int AylıkSiparisIptal { get; set; }
		public int TumZamanlarSiparisIptal { get; set; }
		public int GunlukSiparisKargolandı { get; set; }
		public int HaftalıkSiparisKargolandı { get; set; }
		public int AylıkSiparisKargolandı { get; set; }
		public int TumZamanlarSiparisKargolandı { get; set; }
		public int GunlukSiparisTeslimEdildi { get; set; }
		public int HaftalıkSiparisTeslimEdildi { get; set; }
		public int AylıkSiparisTeslimEdildi { get; set; }
		public int TumZamanlarSiparisTeslimEdildi { get; set; }
		
	}
	
}
