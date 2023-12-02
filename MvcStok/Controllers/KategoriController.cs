using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLKATEGORILER.ToList();
            return View(degerler);

        }
        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniKategori(TBLKATEGORILER p1)
        { 
            db.TBLKATEGORILER.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult GUNCELLE(int id)
        {
            try
            {
                // Kategoriyi veritabanından çekme
                var kategori = db.TBLKATEGORILER.Find(id);

                if (kategori == null)
                {
                    // Kategori bulunamadıysa, özel bir hata sayfasına yönlendirme veya hata mesajı gösterme
                    return View("Error"); // Özel bir hata sayfasına yönlendirme veya hata mesajı gösterme
                }

                // Kategoriyi güncelleme için View'a gönderme
                return View(kategori);
            }
            catch (Exception ex)
            {
                // Hata durumunda yapılacak işlemler
                return View("Error"); // Özel bir hata sayfasına yönlendirme veya hata mesajı gösterme
            }
        }

        [HttpPost]
        public ActionResult GUNCELLE(TBLKATEGORILER model)
        {
            try
            {
                // Kategori güncelleme işlemleri
                var kategori = db.TBLKATEGORILER.Find(model.KATEGORIID);
                if (kategori == null)
                {
                    // Kategori bulunamadıysa, özel bir hata sayfasına yönlendirme veya hata mesajı gösterme
                    return View("Error"); // Özel bir hata sayfasına yönlendirme veya hata mesajı gösterme
                }

                // Güncelleme işlemi
                kategori.KATEGORIAD = model.KATEGORIAD;
                db.SaveChanges();

                // Güncelleme işlemi tamamlandıktan sonra Index sayfasına yönlendirme
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Hata durumunda yapılacak işlemler
                return View("Error"); // Özel bir hata sayfasına yönlendirme veya hata mesajı gösterme
            }
        }

        [HttpPost]
        public ActionResult SIL(int id)
        {
            try
            {
                // Kategori silme işlemleri
                var kategori = db.TBLKATEGORILER.Find(id);
                if (kategori == null)
                {
                    // Kategori bulunamadıysa, özel bir hata sayfasına yönlendirme veya hata mesajı gösterme
                    return View("Error"); // Özel bir hata sayfasına yönlendirme veya hata mesajı gösterme
                }

                // Silme işlemi
                db.TBLKATEGORILER.Remove(kategori);
                db.SaveChanges();

                // Silme işlemi tamamlandıktan sonra Index sayfasına yönlendirme
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Hata durumunda yapılacak işlemler
                return View("Error"); // Özel bir hata sayfasına yönlendirme veya hata mesajı gösterme
            }
        }
    }
}