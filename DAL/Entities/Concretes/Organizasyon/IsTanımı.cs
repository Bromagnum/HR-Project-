using DAL.Entities.Abstracts;
using DAL.Entities.Concretes.KariyerPlanı;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.Concretes.Organizasyon
{
    public class IsTanımı : BaseEntity
    {
        public int Id { get; set; }
        public string Sektor { get; set; } // e.g., Bilişim, Finans
        public string PozisyonAdi { get; set; } // e.g., Yazılım Mühendisi
        public string GerekenNitelikler { get; set; }
        public string GerekenEgitim { get; set; }
        public List<KariyerPlan> KariyerPlanlari { get; set; }
    }
}
