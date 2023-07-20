using Business.Abstract.IServices;
using DataAccess.Concrete.Dal.ClassDal;
using DataAccess.Entities.Nwind;
using ECommerceWebUI.Models.ViewModels.AdminViewModels.ListModel;
using ECommerceWebUI.Models.ViewModels.AdminViewModels.ViewModel;
using ECommerceWebUI.Models.ViewModels.AdminViewModels.ViewModel.Orders;
using ECommerceWebUI.Models.ViewModels.HomeViewModels.ViewComponentModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Web.Helpers;

namespace ECommerceDemo.Controllers
{
	public class AdminController : Controller
	{
		private readonly IOdemeTipiServices odemeTipiServices;
		private readonly ISiparisDurumlariServices siparisDurumlariServices;
		private readonly ICategoryServices categoryServices;
		private readonly IUrunlerServices urunlerServices;
		private readonly IMusteriServices musteriServices;
		private readonly ISatısServices satısServices;
		private readonly ITedarikciServices tedarikciServices;
		private readonly IArananKelimeServices arananKelimeServices;
		public AdminController(ICategoryServices categoryServices, IUrunlerServices urunlerServices, IMusteriServices musteriServices, ISatısServices satısServices, ITedarikciServices tedarikciServices, IArananKelimeServices arananKelimeServices, ISiparisDurumlariServices siparisDurumlariServices, IOdemeTipiServices odemeTipiServices = null)
		{
			this.categoryServices = categoryServices;
			this.urunlerServices = urunlerServices;
			this.musteriServices = musteriServices;
			this.satısServices = satısServices;
			this.tedarikciServices = tedarikciServices;
			this.arananKelimeServices = arananKelimeServices;
			this.siparisDurumlariServices = siparisDurumlariServices;
			this.odemeTipiServices = odemeTipiServices;
		}

		[HttpGet]
		public IActionResult Index()
		{

			var model = new AdminIndexViewModel
			{
				CustomerCount = musteriServices.GetAll().Count(),
				OrderCount = satısServices.GetAll().Where(x => x.SiparisDurumID != 5 && x.SiparisDurumID != 3).Count(),
				ProductsCount = urunlerServices.GetAll().Count(),
				OrderAll = satısServices.GetAll().Count(),

				SonSiparis = satısServices.GetAll().OrderByDescending(x => x.SatisTarihi).Select(x => new AdminIndexSonSiparis
				{
					Musteri = x.MusteriID,
					SiparisDurumu = x.SiparisDurumID,
					SiparisId = x.SatisID,
					SiparisTarihi = x.SatisTarihi
				}).Take(5).ToList(),
				//Sipariş Toplamları
				SiparisToplamları = satısServices.IndexSiparisToplamları().Select(x => new SiparisToplamları
				{
					BirimFiyati = x.BirimFiyati,
					Miktar = x.Miktar,
					SiparisDurumu = x.SiparisDurumu,
					SiparisTarihleri = x.SiparisTarihleri,
				}).ToList(),
				//Miktara Gore Cok Satanlar
				MiktaraGoreCokSatanlar = satısServices.AdminIndexMiktarinaGoreViewModel().Select(x => new MiktaraGoreCokSatanlar
				{
					UrunAdi = x.UrunAdi,
					Miktar = x.Miktar,
					TotalFiyat = x.TotalFiyat



				}).OrderByDescending(x => x.Miktar).Take(5).ToList(),
				//Tutarına Gore Cok Satanlar
				TutarinaGoreCokSatanlar = satısServices.AdminIndexMiktarinaGoreViewModel().Select(x => new TutarinaGoreCokSatanlar
				{
					UrunAdi = x.UrunAdi,
					Miktar = x.Miktar,
					TotalFiyat = x.TotalFiyat
				}).OrderByDescending(x => x.TotalFiyat).Take(5).ToList(),
				//Odeme Durumu Toplam ((bunları grupla!!!) veritabanında
				SiparisDurumunaGore = satısServices.AdminIndexOdemeDurumuToplam().Select(x => new SiparisDurumunaGore
				{
					TotalRakam = x.TotalTutar,
					OdemeDurumu = x.OdemeDurumu,
				}).ToList(),
				PopulerAramaAnahtarKelimeleri = arananKelimeServices.GetAll().GroupBy(x => x.ArananKelimeDescription).Select(g => new PopulerAramaAnahtarKelimeleri
				{
					AnahtarKelime = g.Key,
					AratılanMiktar = g.Count()
				}).Take(5).OrderByDescending(x => x.AratılanMiktar).ToList()


			};
			return View(model);
		}

		//Katalog
		[Route("/Admin/Product/List")]
		[HttpGet]
		public IActionResult ProductList(int id)
		{
			var model = new AdminProductListViewModel
			{
				Kategoriler = categoryServices.GetAll().Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Text = x.KategoriAdi, Value = x.KategoriID.ToString() }).ToList(),
				Urunler = urunlerServices.GetAll(),
				YayınlanmaDurumu = new List<string> { "Seçiniz", "Aktif Ürünler", "Pasif Ürünler" },
				UrunGorseli = new List<string> { "Seçiniz", "Görselli Ürünler", "Görselsiz Ürünler" }
			};
			return View(model);
		}
		[Route("/Admin/Product/List")]
		[HttpPost]
		public IActionResult ProductList(AdminProductListViewModel model)
		{

			return View();
		}
		[Route("/Admin/Product/Category")]
		[HttpGet]
		public IActionResult Category()
		{
			var model = new CategoryListViewModel
			{
				Kategori = categoryServices.GetAll()
			};
			return View(model);
		}
		[Route("/Admin/Product/Category")]
		[HttpPost]
		public IActionResult Category(string name)
		{
			if (name == null)
			{
				var standart = new CategoryListViewModel
				{

					Kategori = categoryServices.GetAll()
				};
				return View(standart);
			}
			var model = new CategoryListViewModel
			{

				Kategori = categoryServices.GetAll().Where(x => x.KategoriAdi.ToLower().Contains(name.ToLower())).ToList()
			};
			return View(model);
		}

		[Route("/Admin/Product/Brands")]
		[HttpGet]
		public IActionResult Brands()
		{
			var model = new MarkaListViewModel
			{
				Marka = tedarikciServices.GetAll()
			};
			return View(model);
		}

		[Route("/Admin/Product/Brands")]
		[HttpPost]
		public IActionResult Brands(string brandName)
		{
			if (brandName == null)
			{
				var marka = new MarkaListViewModel
				{
					Marka = tedarikciServices.GetAll()
				};
				return View(marka);
			}
			var model = new MarkaListViewModel
			{
				Marka = tedarikciServices.GetAll().Where(x => x.SirketAdi.ToLower().Contains(brandName.ToLower())).ToList()
			};
			return View(model);
		}




		//Orders
		[Route("/Admin/Order/List")]
		[HttpGet]
		public IActionResult OrderList()
		{
			var model = new AdminOrderIndexViewModel
			{
				SiparisDurumu = siparisDurumlariServices.GetAll().Select(x => new SelectListItem { Text = x.Description, Value = x.SiparisDurumID.ToString() }).ToList(),
				OdemeTipi = odemeTipiServices.GetAll().Select(x => new SelectListItem { Text = x.OdemeYontemi, Value = x.OdemeTipiID.ToString() }).ToList(),
				Satislar = satısServices.GetAll().OrderByDescending(x => x.SatisTarihi).ToList()
			};
			return View(model);
		}
		[HttpPost]
		[Route("/Admin/Order/List")]
		public IActionResult OrderList(int sn=0, DateTime? sd, DateTime? ld, int? sid,string? ma)
		{//burdan devam
			var model = new AdminOrderIndexViewModel();
			if (sn != 0)
			{
				model.Satislar = satısServices.GetAll().Where(x => x.SatisID == sn).ToList();
			}
			else if (sid!=null)
			{
				model.Satislar = satısServices.GetAll().Where(x => x.SiparisDurumID == sid).ToList();

			}
			else if (ma!=null)
			{
				model.Satislar = satısServices.GetAll().Where(x => x.MusteriID == ma).ToList();

			}

			model.SiparisDurumu = siparisDurumlariServices.GetAll().Select(x => new SelectListItem { Text = x.Description, Value = x.SiparisDurumID.ToString() }).ToList();
			model.OdemeTipi = odemeTipiServices.GetAll().Select(x => new SelectListItem { Text = x.OdemeYontemi, Value = x.OdemeTipiID.ToString() }).ToList();
			
			return View(model);
		}
		[Route("/Admin/ReturnRequest/List")]
		[HttpGet]
		public IActionResult ReturnRequestList()
		{
			return View();
		}
		[Route("/Admin/Order/ShipmentList")]
		[HttpGet]
		public IActionResult Shipment()
		{
			return View();
		}

		//Customer
		[Route("/Admin/Customer/List")]
		[HttpGet]
		public IActionResult CustomerList()
		{
			var model = new CustomerListViewModel
			{
				Customers = musteriServices.GetAll()
			};
			return View(model);
		}
		//End - Customer
	}
}
