using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FitnessWeb.Models.Siniflar
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        [Column(TypeName = "Varchar")]
        public string Adminisim { get; set; }
        [Column(TypeName = "Varchar")]
        public string AdminMailAdresi { get; set; }
        [Column(TypeName = "Varchar")]
        public string AdminSifre { get; set; }

        public string Yetki { get; set; }
    }
}