using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace shnYapi5._0.Entity
{
    public class maps
    {
        [Key]
        public int mapID { get; set; }
        public string stringURL { get; set; }
    }
}
