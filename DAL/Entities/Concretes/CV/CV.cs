using DAL.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.Concretes.CV
{
    public class CV : BaseEntity
    {
        public int Id { get; set; }
        public string TCKimlikNo { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string EgitimDurumu { get; set; }
        public string YabanciDil { get; set; }
        public string BilgisayarBilgileri { get; set; }
        public string Sertifikalar { get; set; }
        public string Deneyimler { get; set; }
        public string Hobiler { get; set; }
        public string Sektor { get; set; }
        public string Pozisyon { get; set; }
    }
}
