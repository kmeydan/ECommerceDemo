using DataAccess.Abstract.Repository.ClassRepository;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Entities.Nwind;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Repository.ClassRepository
{
    public class CategoryDal : BaseRepository<Kategori>, ICategoryDal
    {
        public CategoryDal(EfNorthwindContext dbcontext) : base(dbcontext)
        {
        }
    }
}
