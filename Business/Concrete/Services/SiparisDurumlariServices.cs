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
	public class SiparisDurumlariServices : ISiparisDurumlariServices
	{
		private readonly ISiparisDurumlarıDal siparisDurumlarıDal;

		public SiparisDurumlariServices(ISiparisDurumlarıDal siparisDurumlarıDal)
		{
			this.siparisDurumlarıDal = siparisDurumlarıDal;
		}

		public void Add(SiparisDurumu entity)
		{
			siparisDurumlarıDal.Add(entity);
		}

		public void Delete(SiparisDurumu entity)
		{
			siparisDurumlarıDal.Delete(entity);
		}

		public SiparisDurumu Get(int id)
		{
			return siparisDurumlarıDal.Get(id);
		}

		public List<SiparisDurumu> GetAll()
		{
			return siparisDurumlarıDal.GetAll();
		}

		public void Update(SiparisDurumu entity)
		{
			siparisDurumlarıDal.Update(entity);
		}
	}
}
