using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace shnYapi5._0.Entity
{
    public class phone
    {
        [Key]
        public int phoneID { get; set; }
        public string phoneNumber { get; set; }
    }
}
