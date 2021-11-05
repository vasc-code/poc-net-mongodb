using Application.Boundaries.Cliente.PostCliente;
using Domain.Dtos.Cliente.PostCliente;

namespace Application.UseCase.Cliente.Mapper
{
    internal static class ClienteMapper
    {
        internal static PostClienteInputDto MapInputToDto(this PostClienteInput input)
        {
            return new PostClienteInputDto
            (
                input.Name
            );
        }

        internal static PostClienteOutput MapPostClienteDtoToOutput(this PostClienteOutputDto input)
        {
            return new PostClienteOutput
            (
                input.Id,
                input.Name
            );
        }
    }
}
