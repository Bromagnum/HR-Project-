using DAL.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.Concretes.Mesai_TespitCihaz
{
    public class KimlikTespit : BaseEntity
    {
        public int Id { get; set; }
        public string CihazTuru { get; set; } // Kart, Optik, Parmak İzi
        public string SeriNo { get; set; }
        public string Lokasyon { get; set; }
    }
}
