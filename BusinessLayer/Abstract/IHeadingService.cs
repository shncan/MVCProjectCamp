using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IHeadingService
    {
        List<Heading> GetList();   //Entityi layer'ı ekliyoruz.
        List<Heading> GetListByWriter(); //bu kısmı authentice olan yazar için oluşturduk, tüm listeyi değil de parametre olarak verilen değere göre liste istiyoruz.
        void HeadingAdd(Heading heading);
        Heading GetByID(int id);
        void HeadingDelete(Heading heading);
        void HeadingUpdate(Heading heading);
    }
}
