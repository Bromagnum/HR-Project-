using DAL.Entities.Abstracts;
using DAL.Entities.Concretes.Organizasyon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.Concretes.TMK
{
    public class Malzeme : BaseEntity
    {
        public int Id { get; set; }
        public int GorevYeriId { get; set; }
        public string MalzemeAdi { get; set; }
        public int Miktar { get; set; }
        public string Birim { get; set; }
        public GorevYeri GorevYeri { get; set; }
    }
}
