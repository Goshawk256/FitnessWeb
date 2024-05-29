using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FitnessWeb.Models.Siniflar
{
    public class Antrenör
    {
        [Key]
        public int AntrenörId { get; set; }
        [Column(TypeName = "Varchar")]
        public string Antrenörİsim { get; set; }
        [Column(TypeName = "Varchar")]
        public string AntMailAdresi { get; set; }
        [Column(TypeName = "Varchar")]

        public string AntSifre { get; set; }
        [Column(TypeName = "Varchar")]

        public string Antgörsel { get; set; }

        [Column(TypeName = "Varchar")]
       

        public string DogumTarih { get; set; }
        [Column(TypeName = "Varchar")]
        public string TelefonNo { get; set; }

        public Boolean Durum { get; set; }

        [Column(TypeName = "Varchar")]


        public string Deneyim { get; set; }

        public int kategoriId { get; set; }   
        public virtual Kategori kategori { get; set; }

        public int tercihId { get; set; }
        public virtual Cinsiyet cinsiyet { get; set; }



        public int DnId{ get; set; }
        public virtual Danisanlar danisan { get; set; }

    }
}