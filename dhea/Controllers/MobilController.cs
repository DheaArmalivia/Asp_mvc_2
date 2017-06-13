using asp_mvc_2.Models.EntityManager;
using asp_mvc_2.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace asp_mvc_2.Controllers
{
    public class MobilController : Controller
    {
        //GET : Mobil
        public ActionResult AddMobil()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddMobil(MobilView mv)
        {
            if (ModelState.IsValid)
            {
                MobilManager MM = new MobilManager();
                MM.AddMobil(mv);
                return RedirectToAction("AdminOnly", "Home");
            }
            return View();
        }
        public ActionResult ManageMobilPartial(string status = "")
        {
            //if (User.Identity.IsAuthenticated)
            //{
            string loginName = User.Identity.Name;
            MobilManager MM = new MobilManager();
            MobilDataView MDV = new MobilDataView();
            MDV.MobilProfile = MM.GetMobilData();
            string message = string.Empty;
            if (status.Equals("update"))
                message = "Update Successful";
            else if (status.Equals("delete"))
                message = "Delete Successful";
            ViewBag.Message = message;
            return PartialView(MDV);
            //}
            // return RedirectToAction("Index", "Home");
        }
        public ActionResult UpdateMobilData(int mobilID, string no_plat, string merk, string jenis, string warna, int tahun, int harga)
        {
            MobilView MV = new MobilView();
            MV.id_mobil = mobilID;
            MV.no_plat = no_plat;
            MV.merk = merk;
            MV.jenis = jenis;
            MV.warna = warna;
            MV.tahun = tahun;
            MV.harga_sewa = harga;
            MobilManager MM = new MobilManager();
            MM.UpdateMobil(MV);
            return Json(new { success = true });
        }
        public ActionResult DeleteMobil(int mobilID)
        {
            MobilManager MM = new MobilManager();
            MM.DeleteMobil(mobilID);
            return Json(new { success = true });
        }
        public ActionResult Perubahan()
        {
            return View();
        }

    }
}