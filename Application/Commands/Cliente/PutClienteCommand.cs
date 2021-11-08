using Application.Boundaries.Cliente.PutCliente;
using Application.Commands.Cliente.Validation;
using Infrastructure.Messages;

namespace Application.Commands.Cliente
{
    public class PutClienteCommand : Command<PutClienteOutput>
    {
        public PutClienteCommand() { }

        public PutClienteInput Input { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new PutClienteCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
