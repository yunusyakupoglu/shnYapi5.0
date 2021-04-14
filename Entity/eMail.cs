using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace shnYapi5._0.Entity
{
    public class eMail
    {
        [Key]
        public int emailID { get; set; }
        public string email { get; set; }
    }
}
