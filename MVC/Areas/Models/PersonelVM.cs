namespace MVC.Areas.Models
{
    public class PersonelVM
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Email { get; set; }
        public string TCNo { get; set; }
        public string TelefonNo { get; set; }

        public int? GorevYeriId { get; set; }

    }
}
