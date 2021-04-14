using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace shnYapi5._0.Entity
{
    public class Haritalar
    {
        [Key]
        public int haritaID { get; set; }
        public string Adres { get; set; }
        public string x { get; set; }
        public string y { get; set; }
        public string aciklama { get; set; }
    }
}
