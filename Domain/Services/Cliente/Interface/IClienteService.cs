using Application.Boundaries.Cliente.PostCliente;
using Domain.Dtos.Cliente.DeleteCliente;
using Domain.Dtos.Cliente.PostCliente;
using Domain.Dtos.Cliente.PutCliente;
using System.Threading.Tasks;

namespace Domain.Services.Cliente.Interface
{
    public interface IClienteService
    {
        Task<PostClienteOutputDto> PostClienteAsync(PostClienteInputDto input);
        Task<PutClienteOutputDto> PutClienteAsync(PutClienteInputDto input);
        Task<bool> DeleteClienteAsync(DeleteClienteInputDto input);
    }
}
