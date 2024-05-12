using System.Collections.Generic;
using System.Linq;

namespace ECommerceWebUI.Models.Sepet
{
	public class Card
    {
        public Card()
        {
			CardLines = new List<CartLine>();
        }
        public List<CartLine> CardLines { get; set; }
        public decimal Total
        {
            get { return CardLines.Sum(c => c.Urun.BirimFiyati * c.Quantity); }
        }

    }
}
