using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCE.Application.DTOs;

namespace TCE.Application.Validators
{
    public class CompraDtoValidator : AbstractValidator<CompraDTO>
    {
        public CompraDtoValidator()
        {
            RuleFor(c => c.ValorDevido)
                .GreaterThan(0).WithMessage("O valor da compra deve ser maior que zero.");

            RuleFor(c => c.DataCompra)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("A data da compra não pode estar no futuro.");
        }
    }
}
