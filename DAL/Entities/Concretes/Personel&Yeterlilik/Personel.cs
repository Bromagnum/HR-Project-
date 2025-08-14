using DAL.Entities.Abstracts;
using DAL.Entities.Concretes.Izın;
using DAL.Entities.Concretes.Organizasyon;
using DAL.Entities.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.Concretes
{
    public class Personel : BaseEntity
    {
        public string Ad { get; set; }

        public string SoyAd { get; set; }

        public string? Email { get; set; }

        public string? TCNo { get; set; }

        public string? TelefonNo { get; set; }
        public DateOnly? DogumTarihi { get; set; }

        public string? EgitimDurumu { get; set; }

        public string? SGKNo { get; set; }

        public decimal? Maas { get; set; }

        public string KanGrubu { get; set; }

        public MedeniHal MedeniHal { get; set; }
        public Askerlik Askerlik { get; set; }

        public Cinsiyet Cinsiyet { get; set; }

        public int GorevYeriId { get; set; }
        public GorevYeri GorevYeri { get; set; }
        public List<PersonelNitelik> Nitelikler { get; set; }
        public List<PersonelDegerlendirme> Degerlendirmeler { get; set; }
        public List<MesaiKaydi> Mesailer { get; set; }
        public List<IzinKaydi> Izinler { get; set; }



    }
}
