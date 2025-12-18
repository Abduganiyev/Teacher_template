using System.ComponentModel;
using static Loyiha_dars.Models.Maqola;

namespace Loyiha_dars.Models.ViewModels
{
    public class MaqolaCreateVM
    {
        public string Mavzu { get; set; }
        [DisplayName("Maqola Fayli")]
        public IFormFile MaqolaFayli { get; set; }
        
        public MaqolaHolati Holat { get; set; } = MaqolaHolati.Kutilmoqda;
        [DisplayName("Konferensiyani tanlang")]
        public int KonfrensiyaId { get; set; }
        [DisplayName("Muallifni tanlang")]
        public int MuallifId { get; set; }
    }
}
