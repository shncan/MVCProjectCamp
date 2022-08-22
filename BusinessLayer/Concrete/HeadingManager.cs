using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class HeadingManager : IHeadingService
    {

        IHeadingDal _headingDal;

        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }

        public Heading GetByID(int id)
        {
            return _headingDal.Get(x => x.HeadingID == id);
        }

        public List<Heading> GetList()
        {
            return _headingDal.List();
        }

        public List<Heading> GetListByWriter()  //bu kısmı authentice writer için sonradan hazırladık. heading nesnesi türetmek yerine id kullanmamızın sebebi dışardan parametre olarak vereceğimiz için.
        {
            return _headingDal.List(x => x.WriterID == 4);
        }

        public void HeadingAdd(Heading heading)
        {
            _headingDal.Insert(heading); //Yanlızca nesneyi alıyoruz.
        }

        public void HeadingDelete(Heading heading)
        {
           // heading.HeadingStatus = false; // yalnız bu kötü bir kullanım, manager tarafında en fazla id çağırmalıyız. entityler burada yer almamalı.
            _headingDal.Update(heading); //burada biz ilk önce silme işlemi yapıyorduk ancak bizim sonradan istediğimiz şey
            //silmek yerine aktif-pasif işlemi yapmak yani status durumunu güncelleme işlemi yapmak istiyoruz.
        }

        public void HeadingUpdate(Heading heading)
        {
            _headingDal.Update(heading);
        }
    }
}
