using shnYapi5._0.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shnYapi5._0.Models.ViewModel
{
    public class homePageViewModel
    {
        public List<proje> projes { get; set; }
        public List<homeCards> homeCards { get; set; }
        public List<homeParagraph> paragraphs { get; set; }
    }
}
