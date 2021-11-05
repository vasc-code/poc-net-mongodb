using Application.Boundaries.Cliente.PostCliente;
using Application.Commands.Cliente;
using Application.UseCase.Cliente.Interface;
using Infrastructure.Messages;
using Infrastructure.Messages.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Cliente
{
    public class PostClienteHandler : IRequestHandler<PostClienteCommand, PostClienteOutput>
    {
        private readonly IClienteUseCase _useCase;
        private readonly IMessagesHandler _messagesHandler;

        public PostClienteHandler(IClienteUseCase useCase,
                                  IMessagesHandler messagesHandler)
        {
            _useCase = useCase;
            _messagesHandler = messagesHandler;
        }

        public async Task<PostClienteOutput> Handle(PostClienteCommand command, CancellationToken cancellationToken)
        {
            if (command.IsValid())
            {
                var output = await _useCase.PostClienteAsync(command.Input).ConfigureAwait(false);
                return output;
            }

            foreach (var error in command.ValidationResult.Errors)
            {
                var isError = true;
                await _messagesHandler.SendDomainNotificationAsync
                (
                    new DomainNotification
                    (
                        command.MessageType,
                        error.ErrorMessage,
                        isError
                    )
                ).ConfigureAwait(false);
            }

            return default;
        }
    }
}

