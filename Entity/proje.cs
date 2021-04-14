using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace shnYapi5._0.Entity
{
    public class proje
    {
        [Key]
        public int projeID { get; set; }
        public string projeAdi { get; set; }
        public string projeBasligi { get; set; }
        public string imgYol { get; set; }
        public string imgName { get; set; }
        [NotMapped]
        public IFormFile imgFile { get; set; }
        public string icerik { get; set; }

        public ICollection<Kayit> Kayitlar { get; set; }
    }
}
