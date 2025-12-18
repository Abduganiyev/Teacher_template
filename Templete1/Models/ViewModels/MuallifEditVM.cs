using Microsoft.AspNetCore.Identity;

namespace Loyiha_dars.Models.ViewModels
{
    public class MuallifEditVM
    {
        public int Id { get; set; }
        public string Ism { get; set; }
        public string Familiya { get; set; }
        public string Sharif { get; set; }
        public string IshJoyi { get; set; }
        public string Davlat { get; set; }
        public string IlmiyDaraja { get; set; }
        public string IlmiyUnvon { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string IdentityUserId { get; set; }
        public string YangiParol {  get; set; }
       
    }
}
