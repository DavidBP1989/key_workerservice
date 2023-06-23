using KeyWorkerService.Domain.Models.Local;

namespace KeyWorkerService.Domain.Abstractions.Local
{
    public interface IRequestUsuarioRepository
    {
        Task<IEnumerable<UsuarioRequest>> GetAll();
    }
}
