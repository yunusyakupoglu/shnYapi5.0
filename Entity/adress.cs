using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace shnYapi5._0.Entity
{
    public class adress
    {
        [Key]
        public int adresID { get; set; }
        public string mahalle { get; set; }
        public string sokak { get; set; }
        public string isYeri { get; set; }
        public string No { get; set; }
        public string ilce { get; set; }
        public string sehir { get; set; }
    }
}
