using Application.Boundaries.Cliente.PostCliente;
using Domain.Dtos.Cliente.DeleteCliente;
using Domain.Dtos.Cliente.PostCliente;
using System.Threading.Tasks;

namespace Domain.Services.Cliente.Interface
{
    public interface IClienteService
    {
        Task<PostClienteOutputDto> PostClienteAsync(PostClienteInputDto input);
        Task<bool> DeleteClienteAsync(DeleteClienteInputDto input);
    }
}
