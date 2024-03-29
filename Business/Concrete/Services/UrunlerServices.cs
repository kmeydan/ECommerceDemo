﻿using Business.Abstract.IServices;
using DataAccess.Abstract.IDal.ClassIDal;
using DataAccess.ComplexType.Home;
using DataAccess.Entities.Nwind;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
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

		public List<EnCokSatanlarListViewModel> EnCokSatanlar()
		{
			return urunDal.EnCokSatanlar();
		}

		public List<Urunler> FiyataGoreUrunler(int min, int max)
		{
			return urunDal.GetEx(x => x.BirimFiyati >= min && x.BirimFiyati<=max).ToList();
		}

		public Urunler Get(int id)
		{
			return urunDal.Get(id);
		}

		public List<Urunler> GetAll()
		{
			return urunDal.GetAll();
		}

		public Urunler IsmeGoreUrunSorgu(string name)
		{
			return urunDal.GetEx(x => x.UrunAdi == name).FirstOrDefault();
		}

		public List<Urunler> KategoriyeGoreUrunler(int id)
		{
			return urunDal.GetEx(x=>x.KategoriID==id || id==0).ToList();
		}

		public void Update(Urunler entity)
		{
			urunDal.Update(entity);
		}
        
    }
}
