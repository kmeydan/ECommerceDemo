using DataAccess.Abstract.IDal.ClassIDal;
using DataAccess.ComplexType;
using DataAccess.ComplexType.Home;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.Repository;
using DataAccess.Entities.Nwind;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Dal.ClassDal
{
    public class UrunDal : BaseRepository<Urunler>, IUrunDal
    {
        private readonly EfNorthwindContext _dbcontext;

        public UrunDal(EfNorthwindContext dbcontext):base (dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public List<EnCokSatanlarListViewModel> EnCokSatanlar()
		{
			
			var query = from satısdetay in _dbcontext.SatisDetaylari
						join urun in _dbcontext.Urunler on satısdetay.UrunID equals urun.UrunID
						select new EnCokSatanlarListViewModel
						{
							UrunAdi=urun.UrunAdi,
							UrunId=urun.UrunID,
							BirimFiyati=urun.BirimFiyati,
							SatisMiktari = satısdetay.Miktar
						};
			return query.ToList();
		}
	}
}
