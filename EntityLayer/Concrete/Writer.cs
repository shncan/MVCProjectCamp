using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Writer
    {
        [Key]
        public int WriterID { get; set; }
        [StringLength(250)]
        public string WriterName { get; set; }
        [StringLength(250)]
        public string WriterSurname { get; set; }
        [StringLength(250)]                      //resim uzantılarının artabileceğinden dolayı 100'den 250'ye çıkardık.
        public string WriterImage { get; set; }

        [StringLength(250)]
        public string WriterAbout { get; set; }

        [StringLength(250)]
        public string WriterMail { get; set; }
        [StringLength(250)]
        public string WriterPassword { get; set; }
        [StringLength(250)]
        public string WriterTitle { get; set; }

        public bool WriterStatus { get; set; } // bu kısmı yazar eğer hesabını silerse durumuna göre ekledik. silmek yerine aktif-pasif yapısını kullanacağız.

        public ICollection<Heading> Headings { get; set; } // Bu tarz ilişkilendirmelere attribute eklemiyoruz çünkü iliş

        public ICollection<Content> Contents { get; set; }
    }
}
