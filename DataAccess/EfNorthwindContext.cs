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

        public DbSet<Tedarikci> Tedarikciler { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Musteri> Musteriler { get; set; }
        public DbSet<Satis> Satislar { get; set; }
        public DbSet<Urunler> Urunler{ get; set; }
        public DbSet<SiparisDurumu> SiparisDurumu { get; set; }
        public DbSet<SatisDetaylari> SatisDetaylari { get; set; }
        public DbSet<OdemeTipi> OdemeTipi { get; set; }
        public DbSet<OdemeDurumu> OdemeDurumu { get; set; }
        public DbSet<ArananKelime> ArananKelime { get; set; }


    }
}
