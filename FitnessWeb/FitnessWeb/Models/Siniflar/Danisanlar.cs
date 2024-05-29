using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FitnessWeb.Models.Siniflar
{
    public class Danisanlar
    {
        [Key]
        public int DanisanId { get; set; }

        [Column(TypeName ="Varchar")]
            
        public string DanisanIsım { get; set; }
        [Column(TypeName = "Varchar")]
        public string DabisanMailAdresi { get; set; }
        [Column(TypeName = "Varchar")]
        public string Cinsiyet { get; set; }
        [Column(TypeName = "Varchar")]

        public string DogumTarih { get; set; }
        [Column(TypeName = "Varchar")]
        public string TelefonNo { get; set; }

        [Column(TypeName = "Varchar")]
        public string DanisanSifre { get; set; }
        [Column(TypeName = "Varchar")]
        public string GörselUrl { get; set; }

 
        public Boolean Durum { get; set; }

        public string Kilo { get; set; }
        [Column(TypeName = "Varchar")]
        public string boy { get; set; }
        [Column(TypeName = "Varchar")]
        public string vctyag { get; set; }
        [Column(TypeName = "Varchar")]
        public string kaskütlesi { get; set; }
        [Column(TypeName = "Varchar")]
        public string istenen { get; set; }

        [Column(TypeName = "Varchar")]
        public string kitleindex { get; set; }

        [Column(TypeName = "Varchar")]
        public string ogun1 { get; set; }

        [Column(TypeName = "Varchar")]
        public string ogun2 { get; set; }

        [Column(TypeName = "Varchar")]
        public string ogun3 { get; set; }

        [Column(TypeName = "Varchar")]
        public string ogun4 { get; set; }

        [Column(TypeName = "Varchar")]
        public string ogun5 { get; set; }

        [Column(TypeName = "Varchar")]
        public string ogun6 { get; set; }

        [Column(TypeName = "Varchar")]
        public string eg1 { get; set; }
        [Column(TypeName = "Varchar")]
        public string eg2 { get; set; }
        [Column(TypeName = "Varchar")]
        public string eg3 { get; set; }
        [Column(TypeName = "Varchar")]
        public string eg4 { get; set; }

        public ICollection<Antrenör> Antrenörs { get; set; }
   




    }
}