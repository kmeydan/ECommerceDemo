using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities.Nwind
{
	public class SatisDetaylari:IEntity
	{
		[Key]
		public int SatisID { get; set; }
		public int UrunID { get; set; }
		public decimal BirimFiyati { get; set; }
		public short Miktar{ get; set; }
		public float Indirim{ get; set; }
	}
}
