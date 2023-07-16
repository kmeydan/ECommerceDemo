using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities.Nwind
{
	public class OdemeTipi:IEntity
	{
		public int OdemeTipiID { get; set; }
		public string OdemeYontemi { get; set; }
	}
}
