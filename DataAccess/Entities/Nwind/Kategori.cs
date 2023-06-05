using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities.Nwind
{
    public class Kategori:IEntity
    {
        [Key]
        public int KategoriID { get; set; }
        public string KategoriAdi { get; set; }
        public string Tanimi{ get; set; }
        public string ResimUrl{ get; set; }
    }
}
