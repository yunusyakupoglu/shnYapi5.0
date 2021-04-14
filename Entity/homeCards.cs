using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace shnYapi5._0.Entity
{
    public class homeCards
    {
        [Key]
        public int cardID { get; set; }
        public string baslik { get; set; }
        public string aciklama { get; set; }
        public string icerik { get; set; }
        public string imgYol { get; set; }
        public string imgName { get; set; }
        [NotMapped]
        public IFormFile imgFile { get; set; }
    }
}
