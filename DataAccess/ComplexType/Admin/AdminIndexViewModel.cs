using System;

namespace DataAccess.Abstract.IDal.ClassIDal
{
	public class AdminIndexViewModel
	{
		public decimal BirimFiyati { get; set; }
		public string SiparisDurumu { get; set; }
		public DateTime SiparisTarihleri { get; set; }
		public int Miktar { get; set; }

		public decimal HesaplananTutar
		{
			get { return BirimFiyati * Miktar; }
		}

	}
}