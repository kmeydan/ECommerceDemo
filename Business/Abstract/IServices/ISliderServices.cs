using DataAccess.Entities.Nwind;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.IServices
{
	public interface ISliderServices:IServices<Slider>
	{
		List<Slider> SliderPossitionGet(int id);
	}
}
