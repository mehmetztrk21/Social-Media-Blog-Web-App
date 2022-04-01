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
            RuleFor(x => x.name).NotEmpty().WithMessage("Yazar adı kısmı boş olamaz.");
            RuleFor(x => x.mail).NotEmpty().WithMessage("Mail adresi boş olamaz.");
            RuleFor(x => x.password).NotEmpty().WithMessage("Şifre boş olamaz.");
            RuleFor(x => x.name).MinimumLength(2).WithMessage("Lütfen en az 2 karakterlik giriş yapınız.");
        }
    }
}
