using Application.Boundaries.Cliente.PostCliente;
using Domain.Dtos.Cliente.DeleteCliente;
using Domain.Dtos.Cliente.PostCliente;
using Domain.Dtos.Cliente.PutCliente;
using Domain.Interfaces.Cliente;
using Domain.Services.Cliente.Interface;
using System.Threading.Tasks;

namespace Domain.Services.Cliente
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;

        public ClienteService(IClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<PostClienteOutputDto> PostClienteAsync(PostClienteInputDto input)
        {
            return await _repository.PostClienteAsync(input)
                                    .ConfigureAwait(false);
        }

        public async Task<PutClienteOutputDto> PutClienteAsync(PutClienteInputDto input)
        {
            return await _repository.PutClienteAsync(input)
                                    .ConfigureAwait(false);
        }

        public async Task<bool> DeleteClienteAsync(DeleteClienteInputDto input)
        {
            return await _repository.DeleteClienteAsync(input)
                                    .ConfigureAwait(false);
        }
    }
}
