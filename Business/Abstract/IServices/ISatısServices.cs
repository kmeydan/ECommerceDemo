using DataAccess.Abstract.IDal.ClassIDal;
using DataAccess.ComplexType;
using DataAccess.Entities.Nwind;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.IServices
{
	public interface ISatısServices:IServices<Satis>
	{
		List<AdminIndexViewModel> IndexSiparisToplamları();
		List<AdminIndexMiktarinaGoreViewModel> AdminIndexMiktarinaGoreViewModel();
		List<AdminIndexOdemeDurumuToplam> AdminIndexOdemeDurumuToplam();
	}
}
