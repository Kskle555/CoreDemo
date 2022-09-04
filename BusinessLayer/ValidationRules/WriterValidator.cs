using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Boş geçilemez");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Boş geçilemez");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Şifre boş geçilemez");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("en az 2 karakter girişi yapın");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("en fazla 50 2 karakter girişi yapın");
        }
    }
}
