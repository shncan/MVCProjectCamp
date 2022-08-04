using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{       
    public class Context:DbContext
    {
        //CONTEXT CLASSINDA VERİ TABANINA TABLOLARI YANSITIYORUZ. 
        //CONTEXT CLASSINDA TANIMLANACAK PROPERTYLILER TABLO ISMINE DENK GELİR SQL'DE
        public DbSet<About> Abouts { get; set; } //buraya property olarak entitylayer katmanındaki concrete içindeki değerleri yazıyoruz. (about,Heading gibi) kullanabilmek için de o katmanı buraya refere etmeliyiz.
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Heading> Headings { get; set; }
        public DbSet<Writer> Writers { get; set; }


        //Yukarıdaki kullanımda örnek olarak Heading bizim burada oluşturduğumuz propertynin adı. Ondan türeyen Headings ise sql'de oluşturulacak tablonun adı.


    }
}
