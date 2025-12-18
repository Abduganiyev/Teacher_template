using Loyiha_dars.Models;
using Loyiha_dars.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Loyiha_dars.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminHomeController : Controller
    {
        AppDbContext db;
        UserManager<IdentityUser> _userManager;
        public AdminHomeController(AppDbContext _db, UserManager<IdentityUser> userManager)
        {
            
            db = _db;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Konfrensiya()
        {
            var konf = db.Konfrensiyalar.ToList();
            return View(konf);
        }
        public IActionResult Mualliflar()
        {
            var mualliflar = db.Mualliflar.ToList();
            return View(mualliflar);
        }

        public IActionResult Maqolalar()
        {
            var maqolalar = db.Maqolalar.Include(x=>x.Konfrensiya).Include(x=>x.Muallif).ToList();
            return View(maqolalar);
        }
        public IActionResult AddMaqolalar()
        {
            var konfrensiya = db.Konfrensiyalar.ToList();
            var muallif = db.Mualliflar.Select(
                x => new
                {
                    x.Id,
                    Fullname = x.Ism+x.Familiya
                }).ToList();
            ViewBag.Konfrensiya = new SelectList(konfrensiya, "Id", "Mavzu");
            ViewBag.Mualliflar = new SelectList(muallif, "Id", "Fullname");
            return View();
        }
        [HttpPost]
        public IActionResult AddMaqolalar(MaqolaCreateVM model)
        {
            var muallif = db.Mualliflar.Find(model.MuallifId);
            string fileName = Guid.NewGuid().ToString() +muallif.Ism+ Path.GetExtension(model.MaqolaFayli.FileName);
            string path = Path.Combine("wwwroot/maqolalar",fileName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                model.MaqolaFayli.CopyTo(stream);
            }
            var maqola = new Maqola
            {
                Mavzu = model.Mavzu,
                MaqolaFayli = fileName,
                Holat = model.Holat,
                KonfrensiyaId = model.KonfrensiyaId,
                MuallifId = model.MuallifId

            };
            db.Maqolalar.Add(maqola);
            db.SaveChanges();
            return RedirectToAction("Maqolalar");
        }
        public IActionResult EditMaqolalar(int id)
        {
            var maqola = db.Maqolalar.Find(id);
            var maqolaVM = new MaqolaEditVM
            {
                Id = maqola.Id,
                Mavzu = maqola.Mavzu,
                Holat = maqola.Holat,
                KonfrensiyaId = maqola.KonfrensiyaId,
                MuallifId = maqola.MuallifId,
                EskiFayli = maqola.MaqolaFayli
            };
            var konfrensiya = db.Konfrensiyalar.ToList();
            var muallif = db.Mualliflar.Select(
                x => new
                {
                    x.Id,
                    Fullname = x.Ism + x.Familiya
                }).ToList();
            ViewBag.Konfrensiya = new SelectList(konfrensiya, "Id", "Mavzu");
            ViewBag.Mualliflar = new SelectList(muallif, "Id", "Fullname");
            return View(maqolaVM);
        }
        [HttpPost]
        public IActionResult EditMaqolalar(MaqolaEditVM model)
        {
            var maqola = db.Maqolalar.Find(model.Id);
            maqola.Mavzu = model.Mavzu;
            maqola.Holat = model.Holat;
            maqola.KonfrensiyaId = model.KonfrensiyaId;
            maqola.MuallifId = model.MuallifId;
            if(model.YangiFayli != null)
            {
                string path = Path.Combine("wwwroot/maqolalar", model.EskiFayli);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    model.YangiFayli.CopyTo(stream);
                }
                var muallif = db.Mualliflar.Find(model.MuallifId);
                string fileName = Guid.NewGuid().ToString() + muallif.Ism + Path.GetExtension(model.YangiFayli.FileName);
                string path2 = Path.Combine("wwwroot/maqolalar", fileName);
                using (var stream = new FileStream(path2, FileMode.Create))
                {
                    model.YangiFayli.CopyTo(stream);
                }
                maqola.MaqolaFayli = fileName;
            }
            db.Maqolalar.Update(maqola);
            db.SaveChanges();
            return RedirectToAction("Maqolalar");
        }
        public IActionResult DeleteMaqolalar(int id)
        {
            var maqola = db.Maqolalar.Find(id);
            string path = Path.Combine("wwwroot/maqolalar", maqola.MaqolaFayli);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            db.Maqolalar.Remove(maqola);
            db.SaveChanges();
            return RedirectToAction("Maqolalar");
        }


        public IActionResult Aloqa()
        {
            return View();
        }

        public IActionResult AddKonfrensiya() {
            return View();

        }
        [HttpPost]
        public IActionResult AddKonfrensiya(Konfrensiya konf)
        {
            db.Konfrensiyalar.Add(konf);
            db.SaveChanges();
            return RedirectToAction("Konfrensiya");

        }
        public IActionResult EditKonfrensiya(int id)
        {
            var konf=db.Konfrensiyalar.Find(id);
            return View(konf);

        }
        [HttpPost]
        public IActionResult EditKonfrensiya(Konfrensiya konf)
        {
            db.Konfrensiyalar.Update(konf);
            db.SaveChanges();
            return RedirectToAction("Konfrensiya");

        } 
        public IActionResult DeleteKonfrensiya(int id)
        {
            var konf = db.Konfrensiyalar.Find(id);
            db.Konfrensiyalar.Remove(konf);
            db.SaveChanges();
            return RedirectToAction("Konfrensiya");
        }
        public IActionResult AddMualliflar()
        {
            return View();

        }
        [HttpPost]
        public IActionResult AddMualliflar(CreateMuallifVM model)
        {
            var user = new IdentityUser
            {
                UserName = model.Email,
                Email = model.Email
            };
            var result = _userManager.CreateAsync(user,model.Parol).GetAwaiter().GetResult();
            var mualliflar = new Muallif 
            { 
                Ism = model.Ism,
                Familiya= model.Familiya,
                Sharif= model.Sharif,
                IshJoyi= model.IshJoyi,
                Davlat= model.Davlat,
                IlmiyDaraja= model.IlmiyDaraja,
                IlmiyUnvon= model.IlmiyUnvon,
                Email= model.Email,
                Telefon= model.Telefon,
                IdentityUserId = user.Id
            };
            db.Mualliflar.Add(mualliflar);
            db.SaveChanges();
            return RedirectToAction("Mualliflar");

        }
        public IActionResult EditMuallif(int id)
        {
            var mualliflar = db.Mualliflar.Find(id);
            var muallifVM = new MuallifEditVM
            {
                Id = mualliflar.Id,
                Ism = mualliflar.Ism,
                Familiya = mualliflar.Familiya,
                Sharif = mualliflar.Sharif,
                Davlat = mualliflar.Davlat,
                IshJoyi = mualliflar.IshJoyi,
                IlmiyDaraja = mualliflar.IlmiyDaraja,
                IlmiyUnvon = mualliflar.IlmiyUnvon,
                Email = mualliflar.Email,
                Telefon = mualliflar.Telefon,
                IdentityUserId = mualliflar.IdentityUserId
            };
            return View(muallifVM);
        }
        [HttpPost]
        public IActionResult EditMuallif(MuallifEditVM model)
        {
            var muallif = db.Mualliflar.Find(model.Id);
            muallif.Ism= model.Ism;
            muallif.Familiya= model.Familiya;
            muallif.Sharif= model.Sharif;
            muallif.IshJoyi= model.IshJoyi;
            muallif.Davlat= model.Davlat;
            muallif.IlmiyDaraja= model.IlmiyDaraja;
            muallif.IlmiyUnvon= model.IlmiyUnvon;
            muallif.Email= model.Email;
            muallif.Telefon= model.Telefon;
            db.Mualliflar.Update(muallif);
            db.SaveChanges();
            if (!string.IsNullOrWhiteSpace(model.YangiParol))
            {
                var user = _userManager.FindByIdAsync(muallif.IdentityUserId).GetAwaiter().GetResult();
                var token = _userManager.GeneratePasswordResetTokenAsync(user).GetAwaiter().GetResult();
                _userManager.ResetPasswordAsync(user,token,model.YangiParol).GetAwaiter().GetResult() ;
                
            }
            return RedirectToAction("Mualliflar");
           
        }
        public IActionResult DeleteMuallif(int id)
        {
            var muallif = db.Mualliflar.Find(id);
            var user = _userManager.FindByIdAsync(muallif.IdentityUserId).GetAwaiter().GetResult();
            db.Mualliflar.Remove(muallif);
            db.SaveChanges();
            _userManager.DeleteAsync(user).GetAwaiter().GetType();
            return RedirectToAction("Mualliflar"); 
        }

    }
}
 