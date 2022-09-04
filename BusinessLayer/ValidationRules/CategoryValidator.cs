using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori adını boş geçemezsiniz");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("boş geçemezsiniz");
            RuleFor(x => x.CategoryName).MaximumLength(50).WithMessage("Max50");
            RuleFor(x => x.CategoryName).MinimumLength(2).WithMessage("Min2");
        }

       

       
    }
}
