using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    //Bizim burda elle entityi vermememiz gerekiyor, onun yerine dışardan gelen entityi göndermeliyiz. bu yüzden IRepository<T>
    //Bu yapı ICategory'den daha iyi çünkü bunu tek seferde kullanabilirken ICategory'i diğer tablolara göre tekrar dizayn etmeimz gerekecekti.
    public interface IRepository<T>
    {
        List<T> List();

        void Insert(T p);

        //Get Kısmını sonradan ekledik

        T Get(Expression<Func<T, bool>> filter);  //burada aşağıdaki list'ten farklı olarak tek aradğımız değer gelecekken listte tüm değerler gelir.


        void Delete(T p);

        void Update(T p);

        //şartlı filtrelemeyi ekliyoruz.

        List<T> List(Expression<Func<T, bool>> filter); // buradaki filter işlemin gösterilecek adı.  
    }
}
