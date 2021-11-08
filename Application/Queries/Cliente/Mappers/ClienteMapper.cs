using Application.Boundaries.Cliente.GetClienteById;
using Application.Boundaries.Cliente.GetClientes;
using Domain.Dtos.Cliente.GetClienteById;
using Domain.Dtos.Cliente.GetClientes;
using MongoDB.Bson;
using System.Collections.Generic;

namespace Application.Queries.Cliente.Mappers
{
    internal static class ClienteMapper
    {
        internal static IEnumerable<GetClientesOutput> MapDtoToOutput(this IEnumerable<GetClientesOutputDto> input)
        {
            var list = new List<GetClientesOutput>();

            foreach (var item in input)
            {
                list.Add(new GetClientesOutput(
                    item.Id.ToString(), 
                    item.Name,
                    item.BirthDate,
                    item.ZipCode
                ));
            }

            return list;
        }

        internal static GetClienteByIdInputDto MapToInputDto(this GetClienteByIdInput input)
        {
            ObjectId id;
            var success = ObjectId.TryParse(input.Id, out id);

            if (!success)
            {
                return default;
            }

            return new GetClienteByIdInputDto(
                id
            );           
        }

        internal static GetClienteByIdOutput MapDtoToOutput(this GetClienteByIdOutputDto input)
        {
            return new GetClienteByIdOutput(
                input.Id.ToString(),
                input.Name,
                input.BirthDate,
                input.ZipCode
            );
        }
    }
}
