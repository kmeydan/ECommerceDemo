using Business.Abstract.IServices;
using DataAccess.Abstract.Repository.ClassRepository;
using DataAccess.Entities.Nwind;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Business.Concrete.Services
{
	public class CategoryServices : ICategoryServices
	{
		private readonly ICategoryDal categoryDal;

		public CategoryServices(ICategoryDal categoryDal)
		{
			this.categoryDal = categoryDal;
		}

		public void Add(Kategori entity)
		{
			entity.OlusturulmaTarihi = DateTime.Now;
			categoryDal.Add(entity);
		}

		public void Delete(Kategori entity)
		{
			categoryDal.Delete(entity);
		}

		public Kategori Get(int id)
		{
			return categoryDal.Get(id);
		}

		public List<Kategori> GetAll()
		{
			return categoryDal.GetAll();
		}

		public List<Kategori> IdyeGoreKategoriGetir(int id)
		{
			return categoryDal.GetEx(x => x.KategoriID == id).ToList();
		}

		public void Update(Kategori entity)
		{
			categoryDal.Update(entity);
		}


	}
}
