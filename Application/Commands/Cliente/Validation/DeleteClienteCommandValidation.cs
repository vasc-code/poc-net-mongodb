using FluentValidation;
using MongoDB.Bson;

namespace Application.Commands.Cliente.Validation
{
    public class DeleteClienteCommandValidation : AbstractValidator<DeleteClienteCommand>
    {
        public DeleteClienteCommandValidation()
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
        }
    }
}
