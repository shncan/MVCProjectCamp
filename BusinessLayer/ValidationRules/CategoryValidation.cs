using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator:AbstractValidator<Category> //burası bizden t değeri ister, biz de üzerinde çalıştığımız 
    {
        // Biz burada yani categoryvalidationda category için gerekli doğrulama kurallarını yazacağız. businesslayer'a nuggettan validation yükledik.

        public CategoryValidator() //Doğrulama kurallarını buraya yani constructora yazacağız.
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori adını boş geçemezsiniz.");//burasıyla abstractvalidaor'e gönderdiğimiz t değerinin kurallarını girebilyioruz. burada t değeri bulunduğu yer category olduğu için category kullandık.
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Açıklama boş geçilemez.");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapınız");
            RuleFor(x => x.CategoryName).MaximumLength(20).WithMessage("Lütfen en fazla 20 karakter girişi yapınız.");
        }
    }
}
