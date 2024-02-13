using System;

namespace ECommerceWebUI.Dtos
{
    public class CategoryListDto
    {
        public int KategoriID { get; set; }
        public string KategoriAdi { get; set; }
        public string ResimUrl { get; set; }
        public bool Aktif { get; set; }
    }
}
