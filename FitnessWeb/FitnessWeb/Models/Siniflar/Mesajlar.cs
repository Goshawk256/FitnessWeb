using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FitnessWeb.Models.Siniflar
{
    public class Mesajlar
    {
        [Key]
        public int mesajid { get; set; }
        [Column(TypeName = "Varchar")]
        public string kimden { get; set; }
        [Column(TypeName = "Varchar")]
        public string kime { get; set; }

        [Column(TypeName = "Varchar")]
        public string konu { get; set; }

        [Column(TypeName = "Varchar")]
        public string icerik { get; set; }

        [Column(TypeName = "Date")]
        public DateTime tarih { get; set; }
    }
}