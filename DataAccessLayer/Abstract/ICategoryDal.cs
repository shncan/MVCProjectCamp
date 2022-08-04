using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ICategoryDal:IRepository<Category> // bu isimlendirmede I interface'i // Category kısmı Entity'sini // Dal da çalıştığı katmanı ifade eder.
    {
        //oluşturduğumuz IRepository sayesinde alttaki gibi ayrı ayrı yazıp kod tekrarına yazmaktan kurtulduk. eğer bu şekilde kullanmazsak misal
        //yeni bir öğe ekleyeceğimiz zaman hepsine ayrı ayrı eklememiz gerekecekti.
        
        
        
        
        ////Biz burada CRUD operasyonlarını metod olarak tanımlayacağız.
        //List<Category> List(); // bu ifadeyle türü list olan ismi de list olan bir metod tanımladık. Category'nin altı kırmızıydı, ampulden Entity'i using yaptık.

        //void Insert(Category p); // Ekleme işlemini bu metodla yapıyoruz. Bizim ekleme işlemini gerçekleştirebilmek için parametreye ihtiyacımız var. 

        //void Update(Category p);

        //void Delete(Category p);
        ////Biz yukardaki crud operasyonlarını değil crud operasyonlarının gerçekleşeceği metodları yazdık.

    }

}
