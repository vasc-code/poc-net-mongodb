using Application.Boundaries.Cliente.DeleteCliente;
using Application.Boundaries.Cliente.PostCliente;
using Application.Boundaries.Cliente.PutCliente;
using Application.UseCase.Cliente.Interface;
using Application.UseCase.Cliente.Mapper;
using Domain.Services.Cliente.Interface;
using Infrastructure.Messages;
using Infrastructure.Messages.Interfaces;
using System.Threading.Tasks;

namespace Application.UseCase.Cliente
{
    public class ClienteUseCase : IClienteUseCase
    {
        private readonly IMessagesHandler _messagesHandler;
        private readonly IClienteService _service;

        public ClienteUseCase(IMessagesHandler messagesHandler,
                              IClienteService service)
        {
            _messagesHandler = messagesHandler;
            _service = service;
        }

        public async Task<PostClienteOutput> PostClienteAsync(PostClienteInput input)
        {
            var inputDto = input.MapInputToDto();

            var outputDto = await _service.PostClienteAsync(inputDto).ConfigureAwait(false);

            if (outputDto == null)
            {
                var message = $"Não foi possível criar o Cliente";
                await InvalidClienteUseCase(message).ConfigureAwait(false);
                return default;
            }

            return outputDto.MapDtoToOutput();
        }

        public async Task<PutClienteOutput> PutClienteAsync(PutClienteInput input)
        {
            var inputDto = input.MapInputToDto();

            var outputDto = await _service.PutClienteAsync(inputDto).ConfigureAwait(false);

            if (outputDto == null)
            {
                var message = $"Não foi possível atualizar o Cliente";
                await InvalidClienteUseCase(message).ConfigureAwait(false);
                return default;
            }

            return outputDto.MapDtoToOutput();
        }

        public async Task<bool> DeleteClienteAsync(DeleteClienteInput input)
        {
            var inputDto = input.MapInputToDto();

            var outputDto = await _service.DeleteClienteAsync(inputDto).ConfigureAwait(false);

            if (!outputDto)
            {
                var message = $"Não foi possível deletar o Cliente";
                await InvalidClienteUseCase(message).ConfigureAwait(false);
            }

            return outputDto;
        }

        #region Private
        private async Task<bool> InvalidClienteUseCase(string message)
        {
            var isError = true;

            await _messagesHandler.SendDomainNotificationAsync
            (
                new DomainNotification
                (
                    nameof(ClienteUseCase),
                    message,
                    isError
                )
            ).ConfigureAwait(false);

            return false;
        }
        #endregion
    }
}
