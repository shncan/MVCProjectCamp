using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    //Bu kısım çalışsa bile doğru bir çalışma değil. Çünkü diğer tüm entityler için de bunu yapmamız lazım.
    //Yİne de bu kısım örnek olması açısından silmiyoruz, ancak doğru bir kullanım dğeil.
    
    public class CategoryRepository : ICategoryDal
    {

        Context c = new Context();  // 
        DbSet<Category> _object;


        public void Delete(Category p)
        {
            _object.Remove(p);
            c.SaveChanges();
        }

        public Category Get(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Insert(Category p)
        {
            _object.Add(p); // bura boş olsa bile hata vermez, çünkü void.
            c.SaveChanges(); //bu kod yapılan değişiklikleri kaydet demektir.
        }

        public List<Category> List()
        {
            return _object.ToList(); // eğer değer döndermezsek metod hata verir. Burada ToList entityframework'ta verileri listelemek için kullanılır. 
            //Diğer EntityFramework işlem komutları buradakiyle beraber; ToList, Add,Remove,Find
        }

        public List<Category> List(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Category p)
        {
            c.SaveChanges(); //burada sadece bu kodu kullanmamızın sebebi zaten biz halihazırda değişiklikleri yansıtacağız.
        }
    }
}
