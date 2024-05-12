namespace ECommerceWebUI.Models.ViewModels.CardViewModel
{
	public class MusteriAdressViewModel
	{
        public string MusteriId { get; set; }
        public string Adress { get; set; }
        public string Sehir { get; set; }
        public string Bolge { get; set; }
        public string Ulke { get; set; }
        public string Telefon { get; set; }
        public string EPosta { get; set; }
        public CardSummaryViewModel CardModel { get; set; }
    }
    

}
