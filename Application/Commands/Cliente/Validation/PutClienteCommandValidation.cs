using FluentValidation;
using MongoDB.Bson;

namespace Application.Commands.Cliente.Validation
{
    public class PutClienteCommandValidation : AbstractValidator<PutClienteCommand>
    {
        public PutClienteCommandValidation()
        {
            RuleFor(u => u.Input)
               .Custom((u, Input) =>
               {
                   ObjectId obj;
                   if (!ObjectId.TryParse(u.Id, out obj))
                   {
                       Input.AddFailure("Id informado é inválido");
                   }
               });

            RuleFor(u => u.Input.Name)
                .NotEmpty()
                .WithMessage("O campo NAME está vazio");
        }
    }
}
