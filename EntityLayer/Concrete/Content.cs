using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Content
    {
        [Key]
        public int ContentID { get; set; }
        [StringLength(1000)]
        public string ContentValue { get; set; }

        public DateTime ContentDate { get; set; }

        public int HeadingID { get; set; } // Headingle ilişkili olduğu için.

        public virtual Heading Heading { get; set; }

        public int? WriterID { get; set; } //FOREIGN KEY constraint 'FK_dbo.Contents_dbo.Writers_WriterID' bu hatadan dolayı kapatıyoruz.
        //                                 Yukardaki foreign key hatasının sebebi birden fazla foreign key gelmesiydi, bu yüzden biz writerId boş gelebilir diyor (int?)
        public virtual Writer Writer { get; set; }

        //ContentYazar

        //ContentBaşlık
    }
}
