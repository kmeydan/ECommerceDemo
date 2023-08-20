using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities.Nwind
{
	public class CarouselUrun:IEntity
	{
		[Key]
		public int ID { get; set; }
		public int UrunID { get; set; }
		public int CarouselPossition { get; set; }
	}
}
