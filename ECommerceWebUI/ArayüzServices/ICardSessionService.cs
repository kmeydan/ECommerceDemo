

using ECommerceWebUI.Models.Sepet;

namespace ECommerceWebUI.ArayüzServices
{
	public interface ICardSessionService
	{
		Card GetCard();
		void SetCard(Card card);
	}
}
