using Application.Boundaries.Cliente.GetCliente;
using System.Threading.Tasks;

namespace Application.Queries.Cliente.Interface
{
    public interface IClienteQuery
    {
        Task<GetClienteOutput> GetClienteAsync(GetClienteInput input);
    }
}
