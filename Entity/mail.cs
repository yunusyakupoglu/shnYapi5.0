using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace shnYapi5._0.Entity
{
    public class mail
    {
        [Key]
        public int mailID { get; set; }
        public string mailAdress { get; set; }
    }
}
