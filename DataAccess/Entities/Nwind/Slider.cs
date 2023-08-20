using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities.Nwind
{
	public class Slider:IEntity
	{
		[Key]
		public int SliderID { get; set; }
		public string SliderName { get; set; }
		public string SliderAlt { get; set; }
		public int? SliderPossitionID{ get; set; }
		public string SliderPhotoUrl{ get; set; }
		public string SliderLink{ get; set; }
		public bool SliderActive{ get; set; }
	}
}
