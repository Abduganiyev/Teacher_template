using System.ComponentModel;
using static Loyiha_dars.Models.Maqola;

namespace Loyiha_dars.Models.ViewModels
{
    public class MaqolaEditVM
    {
        public int Id { get; set; }
        public string Mavzu { get; set; }
        public MaqolaHolati Holat { get; set; } = MaqolaHolati.Kutilmoqda;
        [DisplayName("Konfrensiyani tanlang")]
        public int KonfrensiyaId { get; set; }
        [DisplayName("Muallif FIO")]
        public int MuallifId { get; set; }
        [DisplayName("Eski Fayl")]
        public string EskiFayli { get; set; }
        [DisplayName("Yangi Fayl")]
        public IFormFile YangiFayli { get; set; }


    }
}
