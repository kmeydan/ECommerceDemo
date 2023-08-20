using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities.Nwind
{
	public class SliderPossition:IEntity
	{
		public int SliderPossitionID { get; set; }
		public string SliderPossitionName { get; set; }
		public bool SliderEtkin { get; set; }
	}
}
