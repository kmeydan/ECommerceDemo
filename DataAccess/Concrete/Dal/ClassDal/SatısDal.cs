using DataAccess.Abstract.IDal.ClassIDal;
using DataAccess.ComplexType;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.Repository;
using DataAccess.Entities.Nwind;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace DataAccess.Concrete.Dal.ClassDal
{
	public class SatısDal : BaseRepository<Satis>, ISatısDal
	{
		private readonly EfNorthwindContext dbContext;
		public SatısDal(EfNorthwindContext _dbcontext) : base(_dbcontext)
		{
			dbContext = _dbcontext;

		}

		public List<AdminIndexMiktarinaGoreViewModel> AdminIndexMiktarinaGoreViewModel()
		{
			var query = from satıs in dbContext.SatisDetaylari
						join urun in dbContext.Urunler on satıs.UrunID equals urun.UrunID
						join kategori in dbContext.Kategoriler on urun.KategoriID equals kategori.KategoriID	
						group satıs by urun.UrunAdi into g

						select new AdminIndexMiktarinaGoreViewModel
						{
							UrunAdi = g.Key,
							Miktar = g.Sum(s=>s.Miktar),
							TotalFiyat=g.Sum(x=>x.BirimFiyati*x.Miktar),
							
							
							
						};
			return query.ToList();
		}

		public List<AdminIndexOdemeDurumuToplam> AdminIndexOdemeDurumuToplam()
		{
			var query = from satıs in dbContext.Satislar
						join odeme in dbContext.OdemeDurumu on satıs.OdemeDurumuID equals odeme.OdemeDurumuID
						join detay in dbContext.SatisDetaylari on satıs.SatisID equals detay.SatisID
						group detay by odeme.OdemeDurum into g
						
						select new AdminIndexOdemeDurumuToplam
						{
							OdemeDurumu =g.Key,
							TotalTutar=g.Sum(x=>x.BirimFiyati*x.Miktar)
						};
			return query.ToList();
		}

		public List<AdminIndexViewModel> IndexSiparisToplamları()
		{
			var query = from satıs in dbContext.Satislar
						join satısDetay in dbContext.SatisDetaylari on satıs.SatisID equals satısDetay.SatisID
						join satısDurumu in dbContext.SiparisDurumu on satıs.SiparisDurumID equals satısDurumu.SiparisDurumID
						select new AdminIndexViewModel
						{
							SiparisDurumu = satısDurumu.Description,
							SiparisTarihleri=satıs.SatisTarihi,
							BirimFiyati = satısDetay.BirimFiyati,
							Miktar = satısDetay.Miktar


						};
			return query.ToList();
		}

		
	}
}
