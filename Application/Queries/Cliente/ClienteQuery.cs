using Application.Boundaries.Cliente.GetClienteById;
using Application.Boundaries.Cliente.GetClientes;
using Application.Queries.Cliente.Interface;
using Application.Queries.Cliente.Mappers;
using Domain.Interfaces.Cliente;
using Infrastructure.Messages;
using Infrastructure.Messages.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Queries.Mongo
{
    public class ClienteQuery : IClienteQuery
    {
        private readonly IClienteRepository _repository;
        private readonly IMessagesHandler _messagesHandler;

        public ClienteQuery(IClienteRepository repository,
                            IMessagesHandler messagesHandler)
        {
            _repository = repository;
            _messagesHandler = messagesHandler;
        }

        public async Task<IEnumerable<GetClientesOutput>> GetClientesAsync()
        {
            var output = await _repository.GetClientesAsync().ConfigureAwait(false);

            if (output == null)
            {
                await InvalidClienteQueryMessage("Nenhum registro foi encontrado!").ConfigureAwait(false);
                return default;
            }

            return output.MapDtoToOutput();
        }

        public async Task<GetClienteByIdOutput> GetClienteByIdAsync(GetClienteByIdInput input)
        {
            var inputDto = input.MapToInputDto();

            var output = await _repository.GetClienteByIdAsync(inputDto).ConfigureAwait(false);

            if (output == null)
            {
                await InvalidClienteQueryMessage("Registro não encontrado!").ConfigureAwait(false);
                return default;
            }
            
            return output.MapDtoToOutput();
        }

        #region Private
        private async Task InvalidClienteQueryMessage(string message)
        {
            var isError = true;

            await _messagesHandler.SendDomainNotificationAsync
            (
                new DomainNotification
                (
                    nameof(ClienteQuery),
                    message,
                    isError
                )
            ).ConfigureAwait(false);

        }
        #endregion
    }
}
