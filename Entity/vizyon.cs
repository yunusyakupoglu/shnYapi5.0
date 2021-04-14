using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace shnYapi5._0.Entity
{
    public class vizyon
    {
        [Key]
        public int vizyonID { get; set; }
        public string title { get; set; }
        public string arz { get; set; }
        public string talep { get; set; }
        public string content { get; set; }
    }
}
