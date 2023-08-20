using Business.Abstract.IServices;
using DataAccess.Abstract.IDal.ClassIDal;
using DataAccess.Entities.Nwind;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.Services
{
	public class SliderPossitionServices : ISliderPossitionServices
	{
		private readonly ISliderPossitionDal sliderPossitionDal;

		public SliderPossitionServices(ISliderPossitionDal sliderPossitionDal)
		{
			this.sliderPossitionDal = sliderPossitionDal;
		}

		public void Add(SliderPossition entity)
		{
			sliderPossitionDal.Add(entity);
		}

		public void Delete(SliderPossition entity)
		{
			sliderPossitionDal.Delete(entity);
		}

		public SliderPossition Get(int id)
		{
			return sliderPossitionDal.Get(id);
		}

		public List<SliderPossition> GetAll()
		{
			return sliderPossitionDal.GetAll();
		}

		public void Update(SliderPossition entity)
		{
			sliderPossitionDal.Update(entity);
		}
	}
}
