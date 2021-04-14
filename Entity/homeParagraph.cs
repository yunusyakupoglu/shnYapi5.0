using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace shnYapi5._0.Entity
{
    public class homeParagraph
    {
        [Key]
        public int paragraphID { get; set; }
        public string title { get; set; }
        public string section1 { get; set; }
        public string section2 { get; set; }
        public string section3 { get; set; }
    }
}
