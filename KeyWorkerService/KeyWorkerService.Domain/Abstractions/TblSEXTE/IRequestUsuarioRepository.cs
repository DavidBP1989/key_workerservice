using KeyWorkerService.Domain.Models.TblSEXTE;

namespace KeyWorkerService.Domain.Abstractions.TblSEXTE
{
    public interface IRequestUsuarioRepository
    {
        Task Delete();
        Task<int> Insert(IEnumerable<UsuarioRequest> request);
    }
}
