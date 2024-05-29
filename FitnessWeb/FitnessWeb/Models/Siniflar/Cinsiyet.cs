using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessWeb.Models.Siniflar
{
    public class Cinsiyet
    {
        public int CinsiyetId { get; set; }

        public string Tercih { get; set; }

        public ICollection<Antrenör> Antrenörs { get; set; }
    }
}