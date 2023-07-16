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
		public List<MiktaraGoreCokSatanlar> MiktaraGoreCokSatanlar { get; set; }
		public List<TutarinaGoreCokSatanlar> TutarinaGoreCokSatanlar { get; set; }
		public List<SiparisDurumunaGore> SiparisDurumunaGore { get; set; }
		public List<PopulerAramaAnahtarKelimeleri> PopulerAramaAnahtarKelimeleri { get; set; }


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
		public decimal BirimFiyati { get; set; }
		public string SiparisDurumu { get; set; }
		public DateTime SiparisTarihleri { get; set; }
		public int Miktar { get; set; }

		public decimal HesaplananTutar
		{
			get { return BirimFiyati * Miktar; }
		}
	}
	public class MiktaraGoreCokSatanlar
	{
		public string UrunAdi { get; set; }
		public int Miktar { get; set; }
		public decimal TotalFiyat { get; set; }

	}
	public class TutarinaGoreCokSatanlar
	{
		public string UrunAdi { get; set; }
		public int Miktar { get; set; }
		public decimal TotalFiyat { get; set; }

	}
	public class SiparisDurumunaGore
	{
		public string OdemeDurumu { get; set; }
		public decimal TotalRakam { get; set; }
	}
	public class PopulerAramaAnahtarKelimeleri
	{
		public string AnahtarKelime{ get; set; }
		public decimal AratılanMiktar{ get; set; }
	}


}
