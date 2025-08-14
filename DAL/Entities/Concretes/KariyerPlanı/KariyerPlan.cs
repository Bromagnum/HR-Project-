using DAL.Entities.Abstracts;
using DAL.Entities.Concretes.Organizasyon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.Concretes.KariyerPlanı
{
    public class KariyerPlan : BaseEntity
    {
        public int Id { get; set; }
        public int IsTanimiId { get; set; }
        public string AtanabilecekPozisyon { get; set; }
        public string GerekenEgitim { get; set; }
        public string GerekenNitelikler { get; set; }
        public int MinimumSureAy { get; set; }
        public IsTanımı IsTanimi { get; set; }
    }
}
