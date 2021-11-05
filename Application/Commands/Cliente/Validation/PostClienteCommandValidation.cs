using FluentValidation;

namespace Application.Commands.Cliente.Validation
{
    public class PostClienteCommandValidation : AbstractValidator<PostClienteCommand>
    {
        public PostClienteCommandValidation()
        {
            RuleFor(u => u.Input.Name)
                .NotEmpty()
                .WithMessage("O campo NAME está vazio");
        }
    }
}
