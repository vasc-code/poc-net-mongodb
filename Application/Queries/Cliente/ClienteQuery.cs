using Application.Boundaries.Cliente.GetCliente;
using Application.Queries.Cliente.Interface;
using Application.Queries.Cliente.Mappers;
using Domain.Interfaces.Cliente;
using System.Threading.Tasks;

namespace Application.Queries.Mongo
{
    public class ClienteQuery : IClienteQuery
    {
        private readonly IClienteRepository _repository;

        public ClienteQuery(IClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetClienteOutput> GetClienteAsync(GetClienteInput input)
        {
            var inputDto = input.MapToClienteInputDto();

            //var output = await SayHello(_greeter, inputDto).ConfigureAwait(false);

            return new GetClienteOutput(
                default, default
            );
        }
    }
}
