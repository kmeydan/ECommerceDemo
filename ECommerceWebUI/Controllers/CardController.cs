using Business.Abstract.IServices;
using DataAccess.Entities.Identity;
using ECommerceWebUI.ArayüzServices;
using ECommerceWebUI.Models.Sepet;
using ECommerceWebUI.Models.ViewModels.CardViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceWebUI.Controllers
{
	public class CardController : Controller
	{
		private readonly ICardSessionService _cardSessionService;
		private readonly ICardService _cardService;
		private readonly IUrunlerServices _urunlerService;
		private readonly IMusteriServices _musteriService;
		private readonly SignInManager<AppUser> _signIn;
		private readonly UserManager<AppUser> _userManager;

		public CardController(ICardSessionService cardSessionService, ICardService cardService, IUrunlerServices urunlerService, SignInManager<AppUser> signIn, IMusteriServices musteriService, UserManager<AppUser> userManager)
		{
			_cardSessionService = cardSessionService;
			_cardService = cardService;
			_urunlerService = urunlerService;
			_signIn = signIn;
			_musteriService = musteriService;
			_userManager = userManager;
		}

		public IActionResult AddToCard(int productId)
		{
			if (!_signIn.IsSignedIn(User))
			{
				TempData.Add("message","Lütfen Giriş Yapınız");
				return Redirect(Request.Headers["Referer"].ToString());
			}
			var productToBeAdded = _urunlerService.Get(productId);
			var card = _cardSessionService.GetCard();
			_cardService.AddToCard(card, productToBeAdded);
			_cardSessionService.SetCard(card);
			var request = HttpContext.Request;

			TempData.Add("message", "Ürün Başarılı Bir Şekilde Sepete Eklendi.");

			return Redirect(Request.Headers["Referer"].ToString());
		}
		
		public IActionResult RemoveCard(int productId)
		{
			var productToBeRemove=_urunlerService.Get(productId);
			var card=_cardSessionService.GetCard();
			_cardService.RemoveFromCard(card, productId);
			_cardSessionService.SetCard(card);
			var request = HttpContext.Request;
			TempData.Add("message", "Ürün Başarılı Bir Şekilde Silindi");
			return RedirectToAction("Sepet");
		}
		[Route("/Sepet")]
		public IActionResult Sepet()
		{
			var resultCard = _cardSessionService.GetCard();
			CardSummaryViewModel cards = new CardSummaryViewModel
			{
				Card = resultCard
			};
			return View(cards);
		}

		public async Task<IActionResult> TeslimatAdresi()
		{
			
			try
			{
				//sepeti getir
				var resultCard = _cardSessionService.GetCard();
				CardSummaryViewModel cards = new CardSummaryViewModel
				{
					Card = resultCard
				};
				//session müşteri getir
				var user = await _userManager.GetUserAsync(User);
				//musteri tablosundan musteriyi çek
				//!!userid çekemiyor muşteriyi
				var musteri = _musteriService.StringIdIleMusteriGetir(user.Id);
				MusteriAdressViewModel musteriModel = new MusteriAdressViewModel
				{
					Adress = musteri.Adres,
					Bolge = musteri.Bolge,
					EPosta = musteri.EPosta,
					MusteriId = musteri.MusteriID,
					Sehir = musteri.Sehir,
					Telefon = musteri.Telefon,
					Ulke = musteri.Ulke,
					CardModel = cards
				};
				return View(musteriModel);


			}
			catch (Exception)
			{

				return View(new MusteriAdressViewModel());

			}
			//gelen musterinin adresini çek

		}
	}
}
