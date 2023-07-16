using DataAccess.Abstract.Repository;
using DataAccess.ComplexType;
using DataAccess.Entities.Nwind;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract.IDal.ClassIDal
{
	public interface ISatısDal:IRepository<Satis>
	{
		List<AdminIndexViewModel> IndexSiparisToplamları();
		List<AdminIndexMiktarinaGoreViewModel> AdminIndexMiktarinaGoreViewModel();
		List<AdminIndexOdemeDurumuToplam> AdminIndexOdemeDurumuToplam();
	}
}
