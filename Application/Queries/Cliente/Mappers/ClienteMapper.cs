using Application.Boundaries.Cliente.GetCliente;
using Domain.Dtos.Cliente;

namespace Application.Queries.Cliente.Mappers
{
    internal static class ClienteMapper
    {
        internal static ClienteInputDto MapToClienteInputDto(this GetClienteInput input)
        {
            return new ClienteInputDto(
                input.Id,
                input.Name
            );
        }
    }
}
