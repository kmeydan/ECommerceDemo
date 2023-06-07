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
	public class MusteriServices : IMusteriServices
	{
		private readonly IMusteriDal musteriDal;

		public MusteriServices(IMusteriDal musteriDal)
		{
			this.musteriDal = musteriDal;
		}

		public void Add(Musteri entity)
		{
			musteriDal.Add(entity);
		}

		public void Delete(Musteri entity)
		{
			musteriDal.Delete(entity);
		}

		public Musteri Get(int id)
		{
			return musteriDal.Get(id);
		}

		public List<Musteri> GetAll()
		{
			return musteriDal.GetAll();
		}

		public void Update(Musteri entity)
		{
			musteriDal.Update(entity);
		}
	}
}
