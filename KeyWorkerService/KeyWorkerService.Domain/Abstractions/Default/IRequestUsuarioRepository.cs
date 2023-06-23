using KeyWorkerService.Domain.Models.Default;

namespace KeyWorkerService.Domain.Abstractions.Default
{
    public interface IRequestUsuarioRepository
    {
        Task<IEnumerable<UsuarioRequest>> GetAll();
    }
}
