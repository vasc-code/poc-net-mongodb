using Application.Boundaries.Cliente.DeleteCliente;
using Application.Boundaries.Cliente.PostCliente;
using Application.Boundaries.Cliente.PutCliente;
using System.Threading.Tasks;

namespace Application.UseCase.Cliente.Interface
{
    public interface IClienteUseCase
    {
        Task<PostClienteOutput> PostClienteAsync(PostClienteInput input);
        Task<PutClienteOutput> PutClienteAsync(PutClienteInput input);
        Task<bool> DeleteClienteAsync(DeleteClienteInput input);
    }
}
