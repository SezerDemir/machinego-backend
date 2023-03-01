using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachinegoAPI.DataAccess.DTOs.Validators
{
    public class MachineDtoValidator : AbstractValidator<MachineDto>
    {
        public MachineDtoValidator()
        {
            RuleFor(e => e.Model).NotNull().WithMessage("Geçerli bir model girmelisiniz");
            RuleFor(e => e.Brand).NotEmpty().WithMessage("Geçerli bir brand girmelisiniz");
            RuleFor(e => e.Category).NotEmpty().WithMessage("Geçerli bir kategori girmelisiniz");
            RuleFor(e => e.MachineType).NotEmpty().WithMessage("Geçerli bir makine türü girmelisiniz");
            RuleFor(e => e.ProductionYear).NotNull().GreaterThan(1700).LessThanOrEqualTo(DateTime.Now.Year);
        }
    }
}
