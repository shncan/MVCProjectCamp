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
    public class EfHeadingDal:GenericRepository<Heading>, IHeadingDal  // Eğer Ef yani entityframeworkteki classların içini doldurmazsak hata döndürür.
    {
    }
}
