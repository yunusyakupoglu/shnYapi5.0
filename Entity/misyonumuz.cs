using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace shnYapi5._0.Entity
{
    public class misyonumuz
    {
        [Key]
        public int misyonID { get; set; }
        public string title { get; set; }
        public string content { get; set; }
    }
}
