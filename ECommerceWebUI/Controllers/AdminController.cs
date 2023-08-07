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
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
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
		public IActionResult ProductList()
		{
			var model = new AdminProductListViewModel();
			model.Kategoriler = categoryServices.GetAll().Select(x => new SelectListItem { Text = x.KategoriAdi, Value = x.KategoriID.ToString()}).ToList();
			model.YayınlanmaDurumu = new List<string> { "Seçiniz", "Aktif Ürünler", "Pasif Ürünler" };
			model.UrunGorseli = new List<string> { "Seçiniz", "Görselli Ürünler", "Görselsiz Ürünler" };
			model.Urunler = urunlerServices.GetAll().OrderBy(x => x.UrunAdi).ToList();
			
			return View(model);
		}
		[HttpPost]
		[Route("/Admin/Product/List")]
		public IActionResult ProductList(string un,string ub,int k,int yd, int ug)
		{
			var model = new AdminProductListViewModel();
			model.Kategoriler = categoryServices.GetAll().Select(x => new SelectListItem { Text = x.KategoriAdi, Value = x.KategoriID.ToString()}).ToList();
			model.YayınlanmaDurumu = new List<string> { "Seçiniz", "Aktif Ürünler", "Pasif Ürünler" };
			model.UrunGorseli = new List<string> { "Seçiniz", "Görselli Ürünler", "Görselsiz Ürünler" };

			if (un!=null)
			{
				model.Urunler = urunlerServices.GetAll().Where(x => x.UrunAdi.ToLower() == un.ToLower() || x.UrunAdi.ToLower().StartsWith(un.ToLower().Substring(0))).ToList();
			}
			else if (ub!=null)
			{
				model.Urunler = urunlerServices.GetAll().Where(x=>x.Barkod==ub).ToList();
			}
			else if (k!=0)
			{
				model.Urunler = urunlerServices.GetAll().Where(x => x.KategoriID == k).ToList();
			}
			else if (yd != 0)
			{
				if (yd == 1)
				{
					model.Urunler = urunlerServices.GetAll().Where(x => x.Sonlandi == false).ToList();
				}
				else if (yd == 2)
				{
					model.Urunler = urunlerServices.GetAll().Where(x => x.Sonlandi == true).ToList();
				}
			}
			else if (ug!=0)
			{
				if (ug==1)
				{
					model.Urunler = urunlerServices.GetAll().Where(x => x.GorselUrl != null).ToList();
				}
				else if (ug == 2)
				{
					model.Urunler = urunlerServices.GetAll().Where(x => x.GorselUrl == null).ToList();
				}
			}
			else
			{
				model.Urunler = urunlerServices.GetAll().OrderBy(x => x.UrunAdi).ToList();
			}
			return View(model);
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
		public IActionResult OrderList(int? sn, DateTime? sd, DateTime? ld, int? sid, string ma)
		{
			var model = new AdminOrderIndexViewModel();
			model.SiparisDurumu = siparisDurumlariServices.GetAll().Select(x => new SelectListItem { Text = x.Description, Value = x.SiparisDurumID.ToString() }).ToList();
			model.OdemeTipi = odemeTipiServices.GetAll().Select(x => new SelectListItem { Text = x.OdemeYontemi, Value = x.OdemeTipiID.ToString() }).ToList();
			if (sn != null)
			{
				model.Satislar = satısServices.GetAll().Where(x => x.SatisID == sn).OrderByDescending(x => x.SatisTarihi).ToList();
			}
			else if (sid != null)
			{
				model.Satislar = satısServices.GetAll().Where(x => x.SiparisDurumID == sid).OrderByDescending(x => x.SatisTarihi).ToList();
			}
			else if (sd != null)
			{
				model.Satislar = satısServices.GetAll().Where(x => x.SatisTarihi >= sd).OrderByDescending(x => x.SatisTarihi).ToList();
			}
			else if (ld != null)
			{
				model.Satislar = satısServices.GetAll().Where(x => x.SatisTarihi <= ld).OrderByDescending(x => x.SatisTarihi).ToList();
			}
			else if (sd != null && ld != null)
			{
				model.Satislar = satısServices.GetAll().Where(x => x.SatisTarihi >= sd && sd <= ld).OrderByDescending(x => x.SatisTarihi).ToList();
			}
			else if (ma != null)
			{
				model.Satislar = satısServices.GetAll().Where(x => x.MusteriID.ToLower() == ma.ToLower() || x.MusteriID.ToLower().StartsWith(ma.ToLower().Substring(0))).ToList();
			}
			else
			{
				model.Satislar = satısServices.GetAll().OrderByDescending(x => x.SatisTarihi).ToList();
			}

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
		public IActionResult Shipment(int? td, DateTime? sd, DateTime? ld, string ma, int? sn)
		{

			var model = new ShipmentViewModel();
			model.TeslimatDurumu = new List<string> { "Seçiniz", "Teslim Edilmedi", "Teslim Edildi" };

			if (sn != null)
			{
				model.Satislar = satısServices.GetAll().Where(x => x.SatisID == sn).OrderByDescending(x => x.SevkTarihi).ToList();
			}
			else if (sd != null && ld != null)
			{
				model.Satislar = satısServices.GetAll().Where(x => x.SevkTarihi >= sd && x.SevkTarihi <= ld).OrderByDescending(x => x.SevkTarihi).ToList();

			}

			else if (sd != null)
			{
				model.Satislar = satısServices.GetAll().Where(x => x.SevkTarihi >= sd).OrderByDescending(x => x.SevkTarihi).ToList();

			}
			else if (ld != null)
			{
				model.Satislar = satısServices.GetAll().Where(x => x.SevkTarihi <= ld).OrderByDescending(x => x.SevkTarihi).ToList();

			}

			else if (ma != null)
			{
				model.Satislar = satısServices.GetAll().Where(x => x.MusteriID.ToLower() == ma.ToLower() || x.MusteriID.ToLower()
				.StartsWith(ma.ToLower().Substring(0))).OrderByDescending(x => x.SatisTarihi).ToList();

			}
			else if (td == 1)
			{
				model.Satislar = satısServices.GetAll().Where(x => x.TeslimatTarihi == null).OrderByDescending(x => x.SevkTarihi).ToList();

			}
			else if (td == 2)
			{
				model.Satislar = satısServices.GetAll().Where(x => x.TeslimatTarihi != null).OrderByDescending(x => x.SevkTarihi).ToList();

			}
			else
			{
				model.Satislar = satısServices.GetAll().OrderByDescending(x => x.SatisTarihi).ToList();

			}





			return View(model);
		}

		//Customer
		[Route("/Admin/Customer/List")]
		[HttpGet]
		public IActionResult CustomerList()
		{
			var model = new CustomerListViewModel
			{
				Customers = musteriServices.GetAll().OrderByDescending(x => x.OlusturulmaTarihi).ToList()
			};
			return View(model);
		}
		[Route("/Admin/Customer/List")]
		[HttpPost]
		public IActionResult CustomerList(DateTime? startdate,string email,string no,string name)
		{
			var model = new CustomerListViewModel();
			if (startdate != null)
			{
				model.Customers = musteriServices.GetAll().Where(x => x.OlusturulmaTarihi >= startdate).ToList();
			}
			else if (email != null)
			{
				model.Customers = musteriServices.GetAll()
					.Where(x => x.EPosta == email).ToList();
			}
			else if (name != null)
			{
				model.Customers = musteriServices.GetAll()
					.Where(x => x.MusteriAdi == name || x.MusteriAdi.StartsWith(name.ToLower().Substring(0))).ToList();
				
			}
			else if (no != null)
			{
				model.Customers = musteriServices.GetAll()
					.Where(x => x.Telefon == no || x.Telefon.StartsWith(no.Substring(0))).ToList();
			}
			else
			{
				model.Customers = musteriServices.GetAll().OrderByDescending(x => x.OlusturulmaTarihi).ToList();
			}

			return View(model);
		}

		//End - Customer

		//İçerik Yönetimi
		//Banner Yönetimi
		public IActionResult Banner()
		{

			return View();
		}
		public IActionResult BannerEdit()
		{
			return View();
		}
		public IActionResult NewBannerImg()
		{
			return View();
		}
		public IActionResult NewBanner()
		{
			return View();
		}
		//End - Banner Yonetimi

		//Carousel Yönetimi
		public IActionResult Carousel()
		{
			return View();
		}
		public IActionResult CarouselEdit()
		{
			return View();
		}

	}
}
