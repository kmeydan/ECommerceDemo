using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities.Nwind
{
	public class OdemeDurumu:IEntity
	{
		public int OdemeDurumuID { get; set; }
		public string OdemeDurum { get; set; }
	}
}
