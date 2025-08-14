using DAL.Entities.Abstracts;

namespace DAL.Entities.Concretes
{
    public class MesaiKaydi : BaseEntity
    {
        public int Id { get; set; }
        public int PersonelId { get; set; }
        public DateTime GirisSaati { get; set; }
        public DateTime CikisSaati { get; set; }
        public Personel Personel { get; set; }
    }
}