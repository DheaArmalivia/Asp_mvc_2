using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace asp_mvc_2.Models.ViewModel
{
    public class PelangganModel
    {
        public int id_pelanggan { get; set; }
        public string no_id { get; set; }
        [Display(Name = "Nama")]
        public string nama { get; set; }

        [Display(Name = "Alamat")]
        public string alamat { get; set; }
        [Display(Name = "No Telepon 1")]
        public string no_tlp1 { get; set; }
        [Display(Name = "No Telepon 2")]
        public string no_tlp2 { get; set; }


        public class PelangganDataView
        {
            public IEnumerable<PelangganModel> PelangganProfile { get; set; }
        }
    }
}