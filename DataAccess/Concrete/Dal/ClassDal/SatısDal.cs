using DataAccess.Abstract.IDal.ClassIDal;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.Repository;
using DataAccess.Entities.Nwind;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Dal.ClassDal
{
	public class SatısDal : BaseRepository<Satis>, ISatısDal
	{
		private readonly EfNorthwindContext dbContext;
		public SatısDal(EfNorthwindContext _dbcontext) : base(_dbcontext)
		{
			dbContext = _dbcontext;

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
