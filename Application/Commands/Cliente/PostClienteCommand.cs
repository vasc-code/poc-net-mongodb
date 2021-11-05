using Application.Boundaries.Cliente.PostCliente;
using Application.Commands.Cliente.Validation;
using Infrastructure.Messages;

namespace Application.Commands.Cliente
{
    public class PostClienteCommand : Command<PostClienteOutput>
    {
        public PostClienteCommand() { }

        public PostClienteInput Input { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new PostClienteCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
