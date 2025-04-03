using FluentValidation;
using TCE.Application.Commands.CompraCommands;

namespace TCE.Application.Validators
{
    public class CompraCommandValidator : AbstractValidator<CreateCompraCommand>
    {
        public CompraCommandValidator()
        {
            RuleFor(c => c.ValorCompra)
                .GreaterThan(0).WithMessage("O valor da compra deve ser maior que zero.");

            RuleFor(c => c.DataCompra)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("A data da compra não pode estar no futuro.");

            RuleFor(c => c.ClienteId)
                .NotEmpty().WithMessage("A compra deve estar associada a um cliente válido.");

            RuleFor(c => c.Descricao)
                .NotEmpty().WithMessage("Descrição da compra inválida");

            RuleFor(c => c.IdempotencyKey)
                .NotEmpty().WithMessage("A chave de idempotência é obrigatória.");
        }
    }
}
