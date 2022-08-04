using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class About
    {

        [Key] // Attribute eklemek için yani stringlere aralık belirlemek için çağırıyoruz. bunu kullanabilmek için entitylayer'da manage nuget ile entity framework ekliyoruz.
        public int AboutID { get; set; }
        [StringLength(1000)]
        public string AboutDetails { get; set; }
        [StringLength(1000)]
        public string AboutDetails2 { get; set; }
        [StringLength(100)]
        public string AboutImage { get; set; } // Resimleri dosya yolu olarak yükleriz, çünkü resimleri sunucuya yüklemek saçma bir işlem.
        [StringLength(100)]
        public string AboutImage2 { get; set; }

        

    }
}
