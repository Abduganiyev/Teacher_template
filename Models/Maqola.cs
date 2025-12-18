namespace Loyiha_dars.Models
{
    public class Maqola
    {
        public int Id { get; set; }
        public string Mavzu { get; set; }
        public string MaqolaFayli { get; set; }
        public DateTime YuborilganVaqt { get; set; }= DateTime.Now;
        public MaqolaHolati Holat { get; set; } = MaqolaHolati.Kutilmoqda;
        public int KonfrensiyaId { get; set; }
        public Konfrensiya Konfrensiya {  get; set; }
        public int MuallifId {  get; set; }
        public Muallif Muallif { get; set; }
        
        
        
        public enum MaqolaHolati
        { 
            Qabul,
            Kutilmoqda,
            Rad
        }

    }
}
