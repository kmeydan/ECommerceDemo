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
	public class ArananKelimeServices : IArananKelimeServices
	{
		private readonly IArananKelimeDal arananKelimeDal;

		public ArananKelimeServices(IArananKelimeDal arananKelimeDal)
		{
			this.arananKelimeDal = arananKelimeDal;
		}

		public void Add(ArananKelime entity)
		{
			arananKelimeDal.Add(entity);
		}

		public void Delete(ArananKelime entity)
		{
			arananKelimeDal.Delete(entity);
		}

		public ArananKelime Get(int id)
		{
			return arananKelimeDal.Get(id);
		}

		public List<ArananKelime> GetAll()
		{
			return arananKelimeDal.GetAll();
		}

		public void Update(ArananKelime entity)
		{
			arananKelimeDal.Update(entity);
		}
	}
}
