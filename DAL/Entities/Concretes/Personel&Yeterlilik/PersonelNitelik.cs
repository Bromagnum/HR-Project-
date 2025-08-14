using DAL.Entities.Abstracts;

namespace DAL.Entities.Concretes
{
    public class PersonelNitelik : BaseEntity
    {
        public int Id { get; set; }
        public int PersonelId { get; set; }
        public int IQ { get; set; }
        public int EQ { get; set; }
        public string Hobiler { get; set; }
        public Personel Personel { get; set; }
    }
}