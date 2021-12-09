using Application.Boundaries.Cliente.DeleteCliente;
using Application.Boundaries.Cliente.PostCliente;
using Application.Boundaries.Cliente.PutCliente;
using Domain.Dtos.Cliente.DeleteCliente;
using Domain.Dtos.Cliente.PostCliente;
using Domain.Dtos.Cliente.PutCliente;
using MongoDB.Bson;
using System;

namespace Application.UseCase.Cliente.Mapper
{
    internal static class ClienteMapper
    {
        internal static PostClienteInputDto MapInputToDto(this PostClienteInput input)
        {
            return new PostClienteInputDto
            (
                input.Name,
                input.BirthDate,
                input.ZipCode
            );
        }

        internal static PostClienteOutput MapDtoToOutput(this PostClienteOutputDto input)
        {
            return new PostClienteOutput
            (
                input.Id,
                input.Name,
                input.BirthDate,
                input.ZipCode
            );
        }

        internal static PutClienteInputDto MapInputToDto(this PutClienteInput input)
        {
            return new PutClienteInputDto
            (
                ObjectId.Parse(input.Id),
                input.Name,
                input.BirthDate,
                input.ZipCode
            );
        }

        internal static PutClienteOutput MapDtoToOutput(this PutClienteOutputDto input)
        {
            return new PutClienteOutput
            (
                input.Id.ToString(),
                input.Name,
                input.BirthDate,
                input.ZipCode
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
