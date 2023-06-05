using DataAccess.Entities.Nwind;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfNorthwindContext:DbContext
    {
        
        public EfNorthwindContext(DbContextOptions<EfNorthwindContext> options) : base(options)
        {

        }

        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Musteri> Musteriler { get; set; }
        public DbSet<Satis> Satıslar { get; set; }
        public DbSet<Urunler> Urunler{ get; set; }
        

    }
}
