using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities.Nwind
{
	public class CarouselPossition:IEntity
	{
		[Key]
		public int CarrouselPossition { get; set; }
		public string CarrouselPossitionName { get; set; }
	}
}
