using Application.Boundaries.Cliente.DeleteCliente;
using Application.Boundaries.Cliente.PostCliente;
using Application.Commands.Cliente.Validation;
using Infrastructure.Messages;

namespace Application.Commands.Cliente
{
    public class DeleteClienteCommand : Command<bool>
    {
        public DeleteClienteCommand() { }

        public DeleteClienteInput Input { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new DeleteClienteCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
