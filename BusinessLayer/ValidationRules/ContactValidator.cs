﻿using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Mail Adresi Boş Geçilemez.");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu Adı Boş Geçilemez.");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı Adı Boş Geçilemez.");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Lütfen En Az Üç Karakter Girişi Yapınız.");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("Lütfen En Az Üç Karakter Girişi Yapınız.");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("Elli Karakterden Fazla Giriş Yapmayın.");

        }
    }
}
