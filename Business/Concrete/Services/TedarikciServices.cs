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
	public class TedarikciServices : ITedarikciServices
	{
		private readonly ITedarikciDal tedarikciDal;

		public TedarikciServices(ITedarikciDal tedarikciDal)
		{
			this.tedarikciDal = tedarikciDal;
		}

		public void Add(Tedarikci entity)
		{
			tedarikciDal.Add(entity);
		}

		public void Delete(Tedarikci entity)
		{
			tedarikciDal.Delete(entity);
		}

		public Tedarikci Get(int id)
		{
			return tedarikciDal.Get(id);
		}

		public List<Tedarikci> GetAll()
		{
			return tedarikciDal.GetAll();
		}

		public void Update(Tedarikci entity)
		{
			tedarikciDal.Update(entity);
		}
	}
}
