using Application.Boundaries.Cliente.GetClienteById;
using Application.Boundaries.Cliente.GetClientes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Queries.Cliente.Interface
{
    public interface IClienteQuery
    {
        Task<IEnumerable<GetClientesOutput>> GetClientesAsync();
        Task<GetClienteByIdOutput> GetClienteByIdAsync(GetClienteByIdInput input);
    }
}
