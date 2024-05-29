using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FitnessWeb.Models.Siniflar
{
    public class Kategori
    {
        [Key]
        public int KategoriId { get; set; }
        [Column(TypeName = "Varchar")]
        public string KategoriAd { get; set; }

        public Boolean durum { get; set; }

        public ICollection<Antrenör> Antrenörs { get; set; }
   
    }
}