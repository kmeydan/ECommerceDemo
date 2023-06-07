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
	public class UrunlerServices : IUrunlerServices
	{
		private readonly IUrunDal urunDal;

		public UrunlerServices(IUrunDal urunDal)
		{
			this.urunDal = urunDal;
		}

		public void Add(Urunler entity)
		{
			urunDal.Add(entity);
		}

		public void Delete(Urunler entity)
		{
			urunDal.Delete(entity);
		}

		public Urunler Get(int id)
		{
			return urunDal.Get(id);
		}

		public List<Urunler> GetAll()
		{
			return urunDal.GetAll();
		}

        public void Update(Urunler entity)
		{
			urunDal.Update(entity);
		}
        public Urunler GetProductByName(string productName)
        {
			return urunDal.GetProductByName(productName.ToLower());
        }
    }
}
