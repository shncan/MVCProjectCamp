using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    interface IContentService
    {
        List<Content> GetList();
        List<Content> GetListByWriter(int id);  //bu kısmı WriterPanelContentController için yazdık, yazara göre mesajları getirebilmek için.
        List<Content> GetListByHeadingID(int id); //GetByID'den farkı GetByID bize tek değer döndürür, ancak GetListByID ID'ye göre tüm listeyi döndürür.
        //Yukardaki GetListByID kodunu yazmamızdaki sebep tüm listeyi değil de ID'si verilen listeleri getirmek istememiz.

        void ContentAdd(Content content);
        Content GetByID(int id);

        void ContentUpdate(Content content);
        void ContentDelete(Content content);


    }
}
