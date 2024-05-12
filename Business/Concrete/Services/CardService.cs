using Business.Abstract.IServices;
using DataAccess.Entities.Nwind;
using ECommerceWebUI.Models.Sepet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.Services
{
	public class CardService : ICardService
	{
		
		public void AddToCard(Card card, Urunler urun)
		{
			CartLine cartLine=card.CardLines.FirstOrDefault(c=>c.Urun.UrunID==urun.UrunID);
			if (cartLine!=null)
			{
				
                cartLine.Quantity++;
				
                return;
			}
			card.CardLines.Add(new CartLine { Urun = urun,Quantity=1});
		}

		public List<CartLine> List(Card card)
		{
			return card.CardLines;
		}

		public void RemoveFromCard(Card card, int productId)
		{
			card.CardLines.Remove(card.CardLines.FirstOrDefault(x=>x.Urun.UrunID==productId));
		}
	}
}
