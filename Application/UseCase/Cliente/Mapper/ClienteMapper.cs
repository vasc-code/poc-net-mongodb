using Application.Boundaries.Cliente.DeleteCliente;
using Application.Boundaries.Cliente.PostCliente;
using Domain.Dtos.Cliente.DeleteCliente;
using Domain.Dtos.Cliente.PostCliente;
using MongoDB.Bson;

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

        internal static PostClienteOutput MapDtoToOutput(this PostClienteOutputDto input)
        {
            return new PostClienteOutput
            (
                input.Id,
                input.Name
            );
        }

        internal static DeleteClienteInputDto MapInputToDto(this DeleteClienteInput input)
        {
            return new DeleteClienteInputDto
            (
                ObjectId.Parse(input.Id)
            );
        }

    }
}
