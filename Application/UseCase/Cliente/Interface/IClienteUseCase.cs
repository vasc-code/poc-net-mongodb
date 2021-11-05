using Application.Boundaries.Cliente.PostCliente;
using System.Threading.Tasks;

namespace Application.UseCase.Cliente.Interface
{
    public interface IClienteUseCase
    {
        Task<PostClienteOutput> PostClienteAsync(PostClienteInput input);
    }
}
