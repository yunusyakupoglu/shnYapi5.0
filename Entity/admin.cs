﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace shnYapi5._0.Entity
{
    public class admin
    {
        [Key]
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        public ICollection<Kayit> Kayitlar { get; set; }
    }
}
