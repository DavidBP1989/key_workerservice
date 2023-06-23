using KeyWorkerService.Domain.Abstractions.TblSEXTE;
using KeyWorkerService.Domain.Models.TblSEXTE;
using KeyWorkerService.Infrastructure.Data;
using KeyWorkerService.Infrastructure.DataModels.TblSEXTE;
using Microsoft.EntityFrameworkCore;

namespace KeyWorkerService.Infrastructure.Repositories.TblSEXTE
{
    public class UsuarioRepository : IRequestUsuarioRepository
    {
        private readonly TblSexteContext _ctx;
        public UsuarioRepository(TblSexteContext ctx)
        {
            _ctx = ctx;
        }

        public async Task Delete()
        {
            if (_ctx.Usuarios.Any()) await _ctx.Usuarios.ExecuteDeleteAsync();
        }

        public async Task<int> Insert(IEnumerable<UsuarioRequest> request)
        {
            _ctx.Usuarios.AddRange(request.Select(x => new Usuario
            {
                Name = x.Name,
                LastName = x.LastName,
                Age = x.Age,
            }));
            return await _ctx.SaveChangesAsync();
        }
    }
}
