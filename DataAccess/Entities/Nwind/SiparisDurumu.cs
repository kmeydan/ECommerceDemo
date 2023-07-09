using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities.Nwind
{
	public class SiparisDurumu:IEntity
	{
		[Key]
		public int SiparisDurumID { get; set; }
		public string Description { get; set; }
	}
}
