using DataAccess.Entities.Nwind;
using ECommerceWebUI.Models.Sepet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.IServices
{
	public interface ICardService
	{
		void AddToCard(Card card, Urunler urun);
		void RemoveFromCard(Card card, int productId);
		List<CartLine> List(Card card);
	}
}
