﻿using DataAccess.Abstract.IDal.ClassIDal;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.Repository;
using DataAccess.Entities.Nwind;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Dal.ClassDal
{
	public class SliderPossitionDal : BaseRepository<SliderPossition>, ISliderPossitionDal
	{
		public SliderPossitionDal(EfNorthwindContext _dbcontext) : base(_dbcontext)
		{
		}
	}
}
