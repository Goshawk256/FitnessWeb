using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace FitnessWeb.Models.Siniflar
{
    public class Context: DbContext
    {
        public DbSet<Admin>  Admins { get; set; }
        public DbSet<Antrenör> Antrenörs { get; set; }
        public DbSet<Danisanlar> Danisanlars { get; set; }

        public DbSet<Kategori> Kategoris { get; set; }
        public DbSet<Cinsiyet> Cinsiyet { get; set; }
        public DbSet<Mesajlar> Mesajlars{ get; set; }



    }
    
}