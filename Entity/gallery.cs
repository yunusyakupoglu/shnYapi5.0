using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace shnYapi5._0.Entity
{
    public class gallery
    {
        [Key]
        public int imgID { get; set; }
        public string imgYol { get; set; }
        public string imgName { get; set; }
    }
}
