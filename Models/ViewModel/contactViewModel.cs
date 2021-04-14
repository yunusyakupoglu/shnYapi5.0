using shnYapi5._0.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shnYapi5._0.Models.ViewModel
{
    public class contactViewModel
    {
        public List<maps> maps { get; set; }
        public List<adress> adresses { get; set; }
        public List<mail> mails { get; set; }
        public List<phone> phones { get; set; }
        public List<mailSender> MailSenders { get; set; }
    }
}
