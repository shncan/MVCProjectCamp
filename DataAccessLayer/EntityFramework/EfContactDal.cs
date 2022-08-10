using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfContactDal : GenericRepository<Contact>, IContactDal //sırasıyla : sonrasını yapmazsak EfContactDal'ı ne kadar kullanmaya çalışsak da çağıramayız. çünkü bağlantı işlemini kuramayız. sırasıyla generic', entity'i ve DataAcces'i using yapıyoruz.
    {
    }
}
