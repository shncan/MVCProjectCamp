using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class // Bu kısımda ayrı ayrı repostory yaratmak yerine gelen değeri alan genel bir işlem yaptık. 
        //T : class'la da T'nin class olması gerektiğini belirttik. where'le de class olduğu yerlerde kullanma koşulu getirdik.

    {

        Context c = new Context();
        DbSet<T> _object;

        //normalde yukardaki işlemde T yerine O repository ile alakalı olacak şekilde objenin türünü belirleyebiliyorduk. Ancak burada T, karşılığı belirsiz.
        //bu yüzden "ctor" yani constructor kullanacağız.

        public GenericRepository() //constructor metoddur. oluşturulan sınıfın ismiyle aynı oluşurur.
        {
            _object = c.Set<T>();  //senin değerin context'e (c) bağlı olarak gönderilen T değerini al. Set ayarlamak demektir. artık object isimli field'ımız dışardan gelen entity'i alır.
        }



        // burası bileşenlerin tamanını kapsıyor. Generic'in kullanımı böyle.
        public void Delete(T p)
        {
            var deletedEntity = c.Entry(p);
            deletedEntity.State = EntityState.Deleted;
            //_object.Remove(p);
            c.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter);  //silme işlemi için sonradan eklediğimiz get için buraya parametre girmeliyiz. singleordefaulth bize tek bir değer döndürmek için kullandığımız entity fm linq metodur.
        }

        public void Insert(T p)
        {
            var addedEntity = c.Entry(p); //eklenecek nesneyi addedEntity'ye atadık. Ancak hala ekleme işlemi yapmadık.
            addedEntity.State = EntityState.Added; // yapı olarak add methoduyla aynı çalışır. burada state komutlarıyla işlem yaptık. 
            //_object.Add(p);
            c.SaveChanges();
            
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();  //buradaki where entityframework'un komutudur. şartımız filter'dan gelen değere göre listele.
        }

        

        public void Update(T p)
        {
            var updatedEntity = c.Entry(p);
            updatedEntity.State = EntityState.Modified;
            c.SaveChanges();
        }
    }
}
