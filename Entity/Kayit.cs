using System.ComponentModel.DataAnnotations;

namespace shnYapi5._0.Entity
{
    public enum Grade
    {
        A, B, C, D, F
    }
    public class Kayit
    {
        [Key]
        public int kayitID { get; set; }
        public int projeID { get; set; }
        public int adminID { get; set; }
        public Grade? Grade { get; set; }

        public proje proje { get; set; }
        public admin admin { get; set; }
    }
}
