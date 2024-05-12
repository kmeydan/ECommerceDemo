using DataAccess.Entities.Nwind;

namespace ECommerceWebUI.Models.Sepet
{
	public class CartLine
	{
        public Urunler Urun { get; set; }
        public decimal Quantity { get; set; }
    }
}
