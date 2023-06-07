namespace ECommerceWebUI.Models.ViewModels.HomeViewModels.ViewModel
{
    public class ProductDetailViewModel
    {
        public int UrunID { get; set; }
        public string UrunAdi { get; set; }
        public decimal BirimFiyati { get; set; }
        public short HedefStokDuzeyi { get; set; }
        public short YeniSatis { get; set; }
    }
}
