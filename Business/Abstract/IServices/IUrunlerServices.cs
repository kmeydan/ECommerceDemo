using DataAccess.ComplexType.Home;
using DataAccess.Entities.Nwind;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.IServices
{
	public interface IUrunlerServices:IServices<Urunler>
	{
		List<Urunler> KategoriyeGoreUrunler(int id);
		List<Urunler> FiyataGoreUrunler(int min,int max);
		List<EnCokSatanlarListViewModel> EnCokSatanlar();
		Urunler IsmeGoreUrunSorgu(string name);
    }
}
