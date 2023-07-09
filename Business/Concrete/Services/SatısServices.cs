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
	public class SatısServices : ISatısServices
	{
		private readonly ISatısDal satısDal;

		public SatısServices(ISatısDal satısDal)
		{
			this.satısDal = satısDal;
		}

		public void Add(Satis entity)
		{
			satısDal.Add(entity);
		}

		public void Delete(Satis entity)
		{
			satısDal.Delete(entity);
		}

		public Satis Get(int id)
		{
			return satısDal.Get(id);
		}

		public List<Satis> GetAll()
		{
			return satısDal.GetAll();
		}

		public List<AdminIndexViewModel> IndexSiparisToplamları()
		{
			return satısDal.IndexSiparisToplamları();
		}

		public void Update(Satis entity)
		{
			satısDal.Update(entity);
		}
	}
}
