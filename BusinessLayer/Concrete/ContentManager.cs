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
    public class ContentManager : IContentService  //GetListByID diye bir metod tanımladığımız için burası hata verdi, onu da implement etmeliyiz.
    {
        IContentDal _contentDal;  //ilk önce burayı yazıyoruz. ardından Content Manager üzerinden generate constructor yapıp alttaki metodu oluşturuoyruz.

        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }

        public void ContentAdd(Content content)
        {
            throw new NotImplementedException();
        }

        public void ContentDelete(Content content)
        {
            throw new NotImplementedException();
        }

        public void ContentUpdate(Content content)
        {
            throw new NotImplementedException();
        }

        public Content GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Content> GetList()
        {
            throw new NotImplementedException();
        }

        public List<Content> GetListByHeadingID(int id) //buradaki amacımız da listeyi başlık id'sine göre getirmek istememiz.
        {
            //Burası yapı olarak GetByID'ye benziyor, şarta bağlı metod.
            return _contentDal.List(x => x.HeadingID == id); // burası bize id'si eşit olanların listesini getirecek. twitter'da, sözlüklerde olduğu gibi.
        }
    }
}
