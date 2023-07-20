using Business.Abstract.IServices;
using DataAccess.Abstract.IDal.ClassIDal;
using DataAccess.Entities.Nwind;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.Services
{
	public class OdemeTipiServices : IOdemeTipiServices
	{
		private readonly IOdemeTipiDal odemeTipiDal;

		public OdemeTipiServices(IOdemeTipiDal odemeTipiDal)
		{
			this.odemeTipiDal = odemeTipiDal;
		}

		public void Add(OdemeTipi entity)
		{
			odemeTipiDal.Add(entity);
		}

		public void Delete(OdemeTipi entity)
		{
			odemeTipiDal.Delete(entity);
		}

		public OdemeTipi Get(int id)
		{
			return odemeTipiDal.Get(id);
		}

		public List<OdemeTipi> GetAll()
		{
			return odemeTipiDal.GetAll();
		}

		public void Update(OdemeTipi entity)
		{
			odemeTipiDal.Update(entity);
		}

	}
}
