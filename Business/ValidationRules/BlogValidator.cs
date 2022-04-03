using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator:AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.title).NotEmpty().WithMessage("Blog başlığını boş geçemezsiniz.");
            RuleFor(x => x.title).MaximumLength(150).WithMessage("Blog başlığı 150 karakterden uzun olamaz.");
            RuleFor(x => x.content).NotEmpty().WithMessage("Blog içeriğini boş geçemezsiniz.");
            RuleFor(x => x.image).NotEmpty().WithMessage("Blog görselini boş geçemezsiniz.");

        }
    }
}
