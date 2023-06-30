namespace ECommerceWebUI.Models.ViewModels.AdminViewModels.ViewModel
{
    public class ProductViewModel
    {
        public int UrunID { get; set; }
        public string UrunAdi { get; set; }
        public int TedarikciID { get; set; }
        public int KategoriID { get; set; }
        public decimal BirimFiyati { get; set; }
        public bool Sonlandi { get; set; }
        public string UrunGorsel { get; set; }

    }
}
