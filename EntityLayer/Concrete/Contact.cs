using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Contact
    {
        [Key]
        public int ContactID { get; set; }
        [StringLength(250)]
        public string UserName { get; set; }
        [StringLength(250)]
        public string UserMail { get; set; }
        [StringLength(250)]
        public string Subject { get; set; }
        //[StringLength(1000)] burayı boş bırakınca ne olacak onu görmek için böyle yapıyoruz.

        public DateTime ContactDate { get; set; }

        public string Message { get; set; }
    }
}
