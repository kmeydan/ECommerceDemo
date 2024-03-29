﻿using Business.Abstract.IServices;
using DataAccess.Abstract.IDal.ClassIDal;
using DataAccess.ComplexType;
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

		public List<AdminIndexMiktarinaGoreViewModel> AdminIndexMiktarinaGoreViewModel()
		{
			return satısDal.AdminIndexMiktarinaGoreViewModel();
		}

		public List<AdminIndexOdemeDurumuToplam> AdminIndexOdemeDurumuToplam()
		{
			return satısDal.AdminIndexOdemeDurumuToplam();
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
