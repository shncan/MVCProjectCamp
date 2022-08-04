using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    //using DataAccessLayer.Concrete.Repositories; kısmını genericrepository'den tıklayıp getiremediğim için elle yazdım.

    public class CategoryManager : ICategoryService // CategoryService'ın içine CategoryAdd metodu tanımladığımız için burada hata dönderecek. bu yüzden tekrar implemente etmeliyi.z.
    {



        //aşağıdaki açıklama olan içerikleri manager'in içine yazmak yerine inheritance yoluyla almak istiyoruz.


        //GenericRepository<Category> repo = new GenericRepository<Category>();

        //public List<Category> GetAllBl() //sondaki Bl Business Layer'in kısaltması
        //{
        //    return repo.List();
        //}

        //public void CategoryAddBl(Category p)
        //{
        //if (p.CategoryName=="" || p.CategoryName.Length<=3 ||  p.CategoryDescription==""  || p.CategoryName.Length >= 51)

        //{

        //    //Hata mesajı yazdıracağız. bunlardan herhangi biri gerçekleşirse.
        //}

        //else
        //{
        //eğer yukardaki durumlar olmazsa veri girişine izin vereceğiz.
        //repo.Insert(p);

        //}
        //}

        ICategoryDal _categoryDal; //burada IcategoryDal türünde _categoryDal değişkeni oluşturuyoruz. sonrasında bu değişkene değer atayacağız. bunu 

        public CategoryManager(ICategoryDal categoryDal) // burasını CategoryManager'in üstünden constructor methodla oluşturduk.
        {
            _categoryDal = categoryDal;
        }

        public void CategoryAdd(Category category)
        {
            _categoryDal.Insert(category);   //not buradaki _category ICategoryDal'dan türettiğimiz field.
        }

        public void CategoryDelete(Category category)
        {
            _categoryDal.Delete(category); // buradaki delete genericrepostoryden geliyor o da irepostory'i dolduruyor.burada category, categoryvalues'a göre denk gelen veriyi silecek. 
        }

        public void CategoryUpdate(Category category)
        {
            _categoryDal.Update(category);
        }

        public Category GetByID(int id)
        {
            return _categoryDal.Get(x => x.CategoryID == id); //silme işlemimizde bize yardımcı olacak kısım burası. aradığımız id'yi topladaki CategoryID ile eşitleyip silmeyi sağlayacak.
        }

        //yapabilmek için sınıftan constructor method türeteceğiz.


        public List<Category> GetList()
        {
            return _categoryDal.List();


        }



 //       public void CategoryAddBl(Category p)   bu metod yerine daha kullanışlı bir yöntemle ekleme kullanacağımız için yorum satırı yaptık.
 //       {
 //           if (p.CategoryName=="" || p.CategoryStatus==false || p.CategoryName.Length <= 2)  // bu yöntem doğru olsa da böyle yapmayacağız. örnek olması açısından silmedik.
 //           {
 //               //Hata Mesaj
 //           }
 //           else
	//{
 //               _categoryDal.Insert(p); 
 //           }
 //       }
    }   


}
