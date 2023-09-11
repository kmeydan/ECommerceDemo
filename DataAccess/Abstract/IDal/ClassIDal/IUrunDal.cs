using DataAccess.Abstract.Repository;
using DataAccess.ComplexType.Home;
using DataAccess.Concrete.Dal.ClassDal;
using DataAccess.Entities.Nwind;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract.IDal.ClassIDal
{
	public interface IUrunDal:IRepository<Urunler>
	{
		List<EnCokSatanlarListViewModel> EnCokSatanlar();
	}
}
