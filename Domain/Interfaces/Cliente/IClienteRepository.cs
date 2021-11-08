using Application.Boundaries.Cliente.PostCliente;
using Domain.Dtos.Cliente.DeleteCliente;
using Domain.Dtos.Cliente.GetClienteById;
using Domain.Dtos.Cliente.GetClientes;
using Domain.Dtos.Cliente.PostCliente;
using Domain.Dtos.Cliente.PutCliente;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Cliente
{
    public interface IClienteRepository
    {
        Task<PostClienteOutputDto> PostClienteAsync(PostClienteInputDto input);
        Task<PutClienteOutputDto> PutClienteAsync(PutClienteInputDto input);
        Task<IEnumerable<GetClientesOutputDto>> GetClientesAsync();
        Task<GetClienteByIdOutputDto> GetClienteByIdAsync(GetClienteByIdInputDto input);
        Task<bool> DeleteClienteAsync(DeleteClienteInputDto input);
    }
}
