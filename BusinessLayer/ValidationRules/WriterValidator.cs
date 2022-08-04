using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator:AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adını boş geçemezsiniz.");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar Soyadı boş geçemezsiniz.");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkımda kısmı boş geçilemez.");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Unvan kısmı boş geçilemez.");
            RuleFor(x => x.WriterAbout).Must(x => x != null && x.ToUpper().Contains("A")).WithMessage("Bu kısımda en az bir kere a harfi kullanılmalıdır.");
            RuleFor(x => x.WriterSurname).MinimumLength(2).WithMessage("Soyad en az iki karakter olmalı.");
            RuleFor(x => x.WriterSurname).MaximumLength(50).WithMessage("Soyad en fazla 50 karakter olmalı"); 
        }

    }
}
