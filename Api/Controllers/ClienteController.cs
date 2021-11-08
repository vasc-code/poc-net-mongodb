using Application.Boundaries.Cliente.DeleteCliente;
using Application.Boundaries.Cliente.GetClienteById;
using Application.Boundaries.Cliente.GetClientes;
using Application.Boundaries.Cliente.PostCliente;
using Application.Boundaries.Cliente.PutCliente;
using Application.Commands.Cliente;
using Application.Queries.Cliente.Interface;
using Infrastructure.Messages;
using Infrastructure.Messages.Interfaces;
using Infrastructure.Middlewares.Retry.Interface;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ClienteController : BaseController<ClienteController>
    {
        private readonly IRetryMiddleware _retry;
        private readonly int _retryCount;
        private readonly int _nextRetryInSeconds;
        private readonly IClienteQuery _clienteQuery;
        private readonly IMessagesHandler _messagesHandler;

        public ClienteController(INotificationHandler<DomainNotification> notifications,
                                 IMessagesHandler messagesHandler,
                                 IRetryMiddleware retry,
                                 IConfiguration configuration,
                                 IClienteQuery mongoQuery) : base(notifications)
        {
            _messagesHandler = messagesHandler;
            _retry = retry;
            _retryCount = Convert.ToInt32(configuration.GetSection("RetryCount").Value);
            _nextRetryInSeconds = Convert.ToInt32(configuration.GetSection("NextRetryInSeconds").Value);
            _clienteQuery = mongoQuery;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetClientesOutput>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetClientes()
        {
            ConfigureRetry(nameof(GetClientes));

            var output = await GetClientesAsync().ConfigureAwait(false);

            if (IsValidOperation())
            {
                return StatusCode(StatusCodes.Status200OK, output);
            }

            return StatusCode(StatusCodes.Status400BadRequest, GetErrorMessages());
        }

        [HttpGet("GetClienteById")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetClienteByIdOutput))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetClienteById([FromQuery] GetClienteByIdInput input)
        {
            ConfigureRetry(nameof(GetClientes));

            var output = await GetClienteByIdAsync(input).ConfigureAwait(false);

            if (IsValidOperation())
            {
                return StatusCode(StatusCodes.Status200OK, output);
            }

            return StatusCode(StatusCodes.Status400BadRequest, GetErrorMessages());
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(PostClienteOutput))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PostCliente([FromBody] PostClienteInput input)
        {
            ConfigureRetry(nameof(PostCliente));

            var output = await PostClienteAsync(input).ConfigureAwait(false);

            if (IsValidOperation())
            {
                return StatusCode(StatusCodes.Status201Created, output);
            }

            return StatusCode(StatusCodes.Status400BadRequest, GetErrorMessages());
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PutClienteOutput))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutCliente([FromBody] PutClienteInput input)
        {
            ConfigureRetry(nameof(PutCliente));

            var output = await PutClienteAsync(input).ConfigureAwait(false);

            if (IsValidOperation())
            {
                return StatusCode(StatusCodes.Status201Created, output);
            }

            return StatusCode(StatusCodes.Status400BadRequest, GetErrorMessages());
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteCliente([FromQuery] DeleteClienteInput input)
        {
            ConfigureRetry(nameof(DeleteCliente));

            await DeleteClienteAsync(input).ConfigureAwait(false);

            if (IsValidOperation())
            {
                return StatusCode(StatusCodes.Status204NoContent);
            }

            return StatusCode(StatusCodes.Status400BadRequest, GetErrorMessages());
        }

        #region Private
        private async Task<IEnumerable<GetClientesOutput>> GetClientesAsync()
        {
            return await _retry.RetryException.ExecuteAsync
            (
                async () => await _clienteQuery.GetClientesAsync()
                                               .ConfigureAwait(false)
            ).ConfigureAwait(false);
        }        
        
        private async Task<GetClienteByIdOutput> GetClienteByIdAsync(GetClienteByIdInput input)
        {
            return await _retry.RetryException.ExecuteAsync
            (
                async () => await _clienteQuery.GetClienteByIdAsync(input)
                                               .ConfigureAwait(false)
            ).ConfigureAwait(false);
        }

        private async Task<PostClienteOutput> PostClienteAsync(PostClienteInput input)
        {
            return await _retry.RetryException.ExecuteAsync
            (
                async () => await _messagesHandler.SendCommandAsync<PostClienteCommand, PostClienteOutput>
                (
                    new PostClienteCommand { Input = input }
                ).ConfigureAwait(false)
            ).ConfigureAwait(false);
        }

        private async Task<PutClienteOutput> PutClienteAsync(PutClienteInput input)
        {
            return await _retry.RetryException.ExecuteAsync
            (
                async () => await _messagesHandler.SendCommandAsync<PutClienteCommand, PutClienteOutput>
                (
                    new PutClienteCommand { Input = input }
                ).ConfigureAwait(false)
            ).ConfigureAwait(false);
        }

        private async Task<bool> DeleteClienteAsync(DeleteClienteInput input)
        {
            return await _retry.RetryException.ExecuteAsync
            (
                async () => await _messagesHandler.SendCommandAsync<DeleteClienteCommand, bool>
                (
                    new DeleteClienteCommand { Input = input }
                ).ConfigureAwait(false)
            ).ConfigureAwait(false);
        }

        private void ConfigureRetry(string retryContext)
        {
            _retry.ConfigureRetryException
            (
                _retryCount,
                _nextRetryInSeconds,
                retryContext
            );
        }
        #endregion
    }
}
