using DAL.Entities.Abstracts;
using DAL.Entities.Concretes.Organizasyon;

namespace DAL.Entities.Concretes.TMK
{
    public class Kadro: BaseEntity
    {
        public int Id { get; set; }
        public int GorevYeriId { get; set; }
        public int GerekenPersonelSayisi { get; set; }
        public GorevYeri GorevYeri { get; set; }
    }
}