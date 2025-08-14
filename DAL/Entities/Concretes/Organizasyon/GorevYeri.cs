using DAL.Entities.Abstracts;
using DAL.Entities.Concretes.TMK;

namespace DAL.Entities.Concretes.Organizasyon
{
    public class GorevYeri : BaseEntity
    {
        public int Id { get; set; }
        public string Ad { get; set; } 
        public int? UstGorevYeriId { get; set; }
        public GorevYeri UstGorevYeri { get; set; }
        public List<Personel> Personeller { get; set; }
        public List<Kadro> Kadrolar { get; set; }
    }
}