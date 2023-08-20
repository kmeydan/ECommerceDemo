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
	public class SliderServices : ISliderServices
	{
		private readonly ISliderDal sliderDal;

		public SliderServices(ISliderDal sliderDal)
		{
			this.sliderDal = sliderDal;
		}

		public void Add(Slider entity)
		{
			sliderDal.Add(entity);
		}

		public void Delete(Slider entity)
		{
			sliderDal.Delete(entity);
		}

		public Slider Get(int id)
		{
			return sliderDal.Get(id);
		}

		public List<Slider> GetAll()
		{
			return sliderDal.GetAll();
		}

		public List<Slider> SliderPossitionGet(int id)
		{
			return sliderDal.GetEx(x => x.SliderPossitionID == id).ToList();
		}

		public void Update(Slider entity)
		{
			sliderDal.Update(entity);
		}
	}
}
