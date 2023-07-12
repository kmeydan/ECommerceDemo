using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ComplexType
{
	public class AdminIndexMiktarinaGoreViewModel
	{
		public string UrunAdi { get; set; }
		public short Miktar { get; set; }
		public string Kategori { get; set; }
		public decimal ToplamFiyat { get; set; }

	}
}
