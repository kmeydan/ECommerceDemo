using DataAccess.Entities.Nwind;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Business.Abstract.IServices
{
    public interface ICategoryServices:IServices<Kategori>
    {
        List<Kategori> IdyeGoreKategoriGetir(int id);
        List<SelectListItem> GetSelectListItem();
        

    }
}
