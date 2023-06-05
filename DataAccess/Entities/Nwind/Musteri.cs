using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities.Nwind
{
    public class Musteri:IEntity
    {
        [Key]
        public int MusteriID { get; set; }
        public string SirketAdi { get; set; }
        public string MusteriAdi { get; set; }
        public string MusteriUnvani { get; set; }
        public string Adres{ get; set; }
        public string Sehir{ get; set; }
        public string Bolge{ get; set; }
        public string PostaKodu{ get; set; }
        public string Ulke{ get; set; }
        public string Telefon{ get; set; }
        public string Faks{ get; set; }
    }
}
