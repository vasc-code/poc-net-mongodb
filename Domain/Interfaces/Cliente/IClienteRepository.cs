using Application.Boundaries.Cliente.PostCliente;
using Domain.Dtos.Cliente.PostCliente;
using System.Threading.Tasks;

namespace Domain.Interfaces.Cliente
{
    public interface IClienteRepository
    {
        Task<PostClienteOutputDto> PostClienteAsync(PostClienteInputDto input);
    }
}
