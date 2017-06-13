using asp_mvc_2.Models.DB;
using asp_mvc_2.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace asp_mvc_2.Models.EntityManager
{
    public class MobilManager
    {
        public void AddMobil(MobilView mv)
        {
            using (DemoDBEntities db = new DemoDBEntities())
            {
                mobil mb = new mobil();
                mb.no_plat = mv.no_plat;
                mb.merk = mv.merk;
                mb.jenis = mv.jenis;
                mb.warna = mv.warna;
                mb.tahun = mv.tahun;
                mb.harga_sewa = mv.harga_sewa;
                db.mobils.Add(mb);
                db.SaveChanges();
            }
        }

        public void UpdateMobil(MobilView mv)
        {
            using (DemoDBEntities db = new DemoDBEntities())
            {
                mobil mb = db.mobils.Find(mv.id_mobil);
                mb.no_plat = mv.no_plat;
                mb.merk = mv.merk;
                mb.jenis = mv.jenis;
                mb.warna = mv.warna;
                mb.tahun = mv.tahun;
                mb.harga_sewa = mv.harga_sewa;
                db.SaveChanges();
            }
        }

        public List<MobilView> GetMobilData()
        {
            using (DemoDBEntities db = new DemoDBEntities())
            {
                var mobil = db.mobils.Select(o => new MobilView
                {
                    id_mobil = o.id_mobil,
                    no_plat = o.no_plat,
                    merk = o.merk,
                    jenis = o.jenis,
                    warna = o.warna,
                    harga_sewa = o.harga_sewa,

                }).ToList();
                return mobil;
            }
        }

        public void DeleteMobil(int mobilID)
        {
            using (DemoDBEntities db = new DemoDBEntities())
            {
                using (var dbContextTransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var mb = db.mobils.Where(o => o.id_mobil == mobilID);
                        if (mb.Any())
                        {
                            db.mobils.Remove(mb.FirstOrDefault());
                            db.SaveChanges();
                        }
                        dbContextTransaction.Commit();
                    }
                    catch
                    {
                        dbContextTransaction.Rollback();
                    }
                }
            }
        }
        public void AddPelanggan(PelangganModel pv)
        {
            using (DemoDBEntities db = new DemoDBEntities())
            {
                pelanggan ou = new pelanggan();
                ou.nama = pv.nama;
                ou.alamat = pv.alamat;
                ou.no_tlp1 = pv.no_tlp1;
                ou.no_tlp2 = pv.no_tlp2;
                db.pelanggans.Add(ou);
                db.SaveChanges();
            }

        }

        public List<PelangganModel> GetPelangganData()
        {
            using (DemoDBEntities db = new DemoDBEntities())
            {
                var pelanggan = db.pelanggans.Select(o => new PelangganModel
                {

                    nama = o.nama,
                    alamat = o.alamat,
                    no_tlp1 = o.no_tlp1,
                    no_tlp2 = o.no_tlp2,

                }).ToList();
                return pelanggan;
            }
        }

    }
}