using DAL.Entities.Concretes.Organizasyon;

namespace MVC.Areas.Models
{
    public class GorevYeriVM
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public int? UstGorevYeriId { get; set; }
        
    }
}
