using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Message
    {
        //BU KISMI SİTE KULLANICILARININ BİRBİRLERİYLE DE MESAJLAŞABİLMESİ İÇİN OLUŞTURDUK.

        [Key]
        public int MessageID { get; set; }

        [StringLength(250)]
        public string SenderMail { get; set; }  //mesajlaşmada bu kısım gönderen alttaki de alıcı olacak.

        [StringLength(250)]
        public string ReceiverMail { get; set; }

        [StringLength(250)]
        public string Subject { get; set; }        //önceki subject kullanımlarında olduğu gibi genel değil de bir konuya bağlı mesajlar olsun istiyoruz.


        public string MessageContent { get; set; }


        public DateTime MessageDate { get; set; }

    }
}
