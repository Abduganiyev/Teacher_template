using System.ComponentModel;

namespace Loyiha_dars.Models
{
    public class Konfrensiya
    {
        public int Id { get; set; }
        public string Mavzu { get; set; }
        public string Tavsif { get; set; }
        [DisplayName("Boshlanish Vaqti")]
        public DateTime BoshlanishVaqti { get; set; }
        [DisplayName("Tugash Vaqti")]
        public DateTime TugashVaqti { get; set; }
        [DisplayName("Maqola Yuborish  Vaqti")]
        public DateTime MaqolaYuborishVaqti { get; set; }
        [DisplayName("Maqola Narxi")]
        public int MaqolaNarxi {  get; set; }
        public string Manzil { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        [DisplayName("Maqola Talablari")]
        public string MaqolaTalablari { get; set; }
        [DisplayName("Maqola Namunasi")]
        public string MaqolaNamuna { get; set; }

        public ICollection<Maqola> Maqolalar { get; set; }

    }
}
