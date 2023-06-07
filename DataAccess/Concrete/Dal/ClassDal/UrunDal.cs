using DataAccess.Abstract.IDal.ClassIDal;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.Repository;
using DataAccess.Entities.Nwind;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Dal.ClassDal
{
    public class UrunDal : BaseRepository<Urunler>, IUrunDal
    {
        private readonly EfNorthwindContext _dbcontext;
        public UrunDal(EfNorthwindContext _dbcontext) : base(_dbcontext)
        {
        }
        public Urunler GetProductByName(string productName)
        {
            return _dbcontext.Urunler.FirstOrDefault(p => p.UrunAdi.ToLower() == productName.ToLower());
        }
    }
}
