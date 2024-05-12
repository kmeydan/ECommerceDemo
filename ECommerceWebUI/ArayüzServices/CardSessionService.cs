using Business.Abstract.IServices;
using ECommerceWebUI.Extensions;
using ECommerceWebUI.Models.Sepet;
using Microsoft.AspNetCore.Http;

namespace ECommerceWebUI.ArayüzServices
{
	public class CardSessionService : ICardSessionService
	{
		private readonly IHttpContextAccessor _httpContextAccessor;

		public CardSessionService(IHttpContextAccessor httpContextAccessor)
		{
			this._httpContextAccessor = httpContextAccessor;
		}

		public Card GetCard()
		{
			Card cardToCheck = _httpContextAccessor.HttpContext.Session.GetObject<Card>("card");
			if (cardToCheck == null)
			{
				_httpContextAccessor.HttpContext.Session.SetObject("card", new Card());
				cardToCheck = _httpContextAccessor.HttpContext.Session.GetObject<Card>("card");
			}
			return cardToCheck;

		}

		public void SetCard(Card card)
		{
			_httpContextAccessor.HttpContext.Session.SetObject("card", card);
		}
	}
}
