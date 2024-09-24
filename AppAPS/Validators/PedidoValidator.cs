using AppAPS.Entities;
using FluentValidation;

namespace AppAPS.Validators
{
    public class PedidoValidator : AbstractValidator<Pedido>
    {
        public PedidoValidator()
        {
            RuleFor(x => x.Cliente).NotEmpty().WithMessage("O nome do cliente é obrigatório.");
            RuleFor(x => x.Rua).NotEmpty().WithMessage("Rua é obrigatória.");
            RuleFor(x => x.Bairro).NotEmpty().WithMessage("Bairro é obrigatório.");
            RuleFor(x => x.FormaEntrega).NotEmpty().WithMessage("Forma de entrega é obrigatória.");
            RuleFor(x => x.FormaPagamento).NotEmpty().WithMessage("Forma de pagamento é obrigatória.");

        }
    }
}
