using DAL.Entities.Concretes.Organizasyon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class GorevYeriDTO
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public int? UstGorevYeriId { get; set; }
        
    }
}
