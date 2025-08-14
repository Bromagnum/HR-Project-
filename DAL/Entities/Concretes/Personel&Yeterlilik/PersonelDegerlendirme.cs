using DAL.Entities.Abstracts;

namespace DAL.Entities.Concretes
{
    public class PersonelDegerlendirme : BaseEntity
    {
        public int Id { get; set; }
        public int PersonelId { get; set; }
        public DateTime DegerlendirmeTarihi { get; set; }
        public string Diksiyon { get; set; }
        public string FizikiGorunum { get; set; }
        public bool AracKullanma { get; set; }
        public string InsanIliskileri { get; set; }
        public string ProblemCozme { get; set; }
        public string Notlar { get; set; }
        public Personel Personel { get; set; }
    }
}