using Business.Abstract.IServices;
using DataAccess.Entities.Identity;
using DataAccess.Entities.Nwind;
using ECommerceWebUI.Models.ViewModels.HomeViewModels;
using ECommerceWebUI.Models.ViewModels.HomeViewModels.ListModel;
using ECommerceWebUI.Models.ViewModels.HomeViewModels.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace ECommerce.Controllers
{

	public class HomeController : Controller
	{
		private readonly ICategoryServices categoryServices;
		private readonly IUrunlerServices urunlerServices;

		//Account
		private readonly SignInManager<AppUser> _signInManager;
		private readonly UserManager<AppUser> _userManager;

		public HomeController(ICategoryServices categoryServices, IUrunlerServices urunlerServices, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
		{
			this.categoryServices = categoryServices;
			this.urunlerServices = urunlerServices;
			_userManager = userManager;
			_signInManager = signInManager;
		}

		public IActionResult Index()
		{
			var model = new UrunlerListViewModel
			{
				Kategoriler = categoryServices.GetAll()
			};
			return View(model);
		}
		
		[HttpGet]
		[Route("/Sepet")]
		public IActionResult ShoppingCart()
		{
			return View();
		}
		[HttpGet]
		[Route("/Detay")]
		public IActionResult ProductDetail(int id=0)
		{
			var result = urunlerServices.Get(id);
			if (result == null)
			{
				ModelState.AddModelError("", $"{id}' id ' ye sahip ürün stokta kalmamıştır.");
				return RedirectToAction("Index");
			}
			var model = new ProductDetailViewModel
			{
				UrunID = result.UrunID,
				BirimFiyati = result.BirimFiyati,
				UrunAdi = result.UrunAdi,
				YeniSatis = result.YeniSatis,
			};

			return View(model);
		}
		[HttpGet]
		[Route("/Urunler")]
		public IActionResult Products(int p = 1, int c = 0, int ps = 60 , int df=0)
		{
			var result = urunlerServices.KategoriyeGoreUrunler(c).ToList();

			var model = new UrunlerListViewModel
			{
				UrunlerMaksPrice = Convert.ToInt32(result.Max(x => x.BirimFiyati)),
				UrunlerMinPrice = Convert.ToInt32(result.Min(x => x.BirimFiyati)),
				Kategoriler = categoryServices.GetAll(),
				Urunlers = result.Skip((p - 1) * ps).Take(ps).ToList(),
				PageSize = ps,
				PageCount = (int)Math.Ceiling(result.Count / (double)ps),
				CurrentCategory = c,
				CurrentPage = p
			};
			return View(model);
		}
		[HttpGet]
		public IActionResult ProductsFilter(int min, int max)
		{
			var model = new UrunlerListViewModel
			{
				Urunlers = urunlerServices.FiyataGoreUrunler(min, max)
			};

			return Json(model);
		}
		[HttpGet]
		public IActionResult JsonUrunGetir(int c = 0, int ps = 20, int p = 1)
		{
			var result = urunlerServices.KategoriyeGoreUrunler(c);
			var pagesize = ps;
			var model = new UrunlerListViewModel
			{
				UrunlerMaksPrice = Convert.ToInt32(result.Max(x => x.BirimFiyati)),
				UrunlerMinPrice = Convert.ToInt32(result.Min(x => x.BirimFiyati)),
				Kategoriler = categoryServices.GetAll(),
				Urunlers = result.Skip((p - 1) * pagesize).Take(pagesize).ToList(),
				PageSize = pagesize,
				PageCount = (int)Math.Ceiling(result.Count / (double)pagesize),
				CurrentCategory = c,
				CurrentPage = p
			};
			var json = JsonConvert.SerializeObject(model);
			return Json(model);
		}
		public IActionResult Login()
		{
			return View(new LoginViewModel());
		}
		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel model)
		{
			var user= await _userManager.FindByEmailAsync(model.Eposta);
			if (user == null)
			{
				ModelState.AddModelError("", "Kullanıcı Bulunamadı");
				return View();
			}
			var result=await _signInManager.PasswordSignInAsync(user,model.Password, model.RememberMe,false);
			if (result.Succeeded)
			{
				return RedirectToAction("Index", "Admin");
			}
			else
			{
				ModelState.AddModelError("", "Parola Hatalı");
				return View();
			}
		}
		public IActionResult Register()
		{
			return View(new RegisterViewModel());
		}
		[HttpPost]
		public async Task<IActionResult> Register(RegisterViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}
			var resultEmail= await _userManager.FindByEmailAsync(model.Email);
			var resultUserName = await _userManager.FindByNameAsync(model.Name);
			if (resultUserName != null)
			{
				ModelState.AddModelError("", "Kullanıcı Adı Zaten Kullanılıyor");
				return View();
			}else if (resultEmail != null)
			{
				ModelState.AddModelError("", "E-Mail Zaten Kullanılıyor");
				return View();
			}
			
			
			
			var user = new AppUser()
			{
				Email = model.Email,
				PhoneNumber = model.PhoneNumber,
				UserName = model.Name,

			};
			var userResult=await _userManager.CreateAsync(user, model.Password);
			if (userResult.Succeeded)
			{
				ViewBag.KayitDurumu = "Başarılı";
			}
			else
			{
				ViewBag.KayitDurumu = "Başarısız";
			}
			return View();
		}
		[HttpGet]
		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Index","Home");
		}
		[HttpGet]
		[Route("/Iletisim")]
		public IActionResult Contact()
		{
			return View();
		}
		

	}
}
