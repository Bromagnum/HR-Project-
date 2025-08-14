using DAL.Entities.Abstracts;

namespace DAL.Entities.Concretes.Izın
{
    public class IzinKaydi : BaseEntity
    {
        public int Id { get; set; }
        public int PersonelId { get; set; }
        public DateTime BaslangicTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }
        public string IzinTuru { get; set; } // Yıllık, Hastalık, vb.
        public string Aciklama { get; set; }
        public Personel Personel { get; set; }
    }
}