using KeyWorkerService.Domain.Abstractions.Local;
using KeyWorkerService.Domain.Models.Local;
using KeyWorkerService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace KeyWorkerService.Infrastructure.Repositories.Local
{
    public class UsuarioRepository : IRequestUsuarioRepository
    {
        private readonly DefaultContext _ctx;
        public UsuarioRepository(DefaultContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<UsuarioRequest>> GetAll()
        {
            var dbUsuarios = await _ctx.Usuarios.ToListAsync();
            var usuarios = dbUsuarios.Select(x => new UsuarioRequest
            {
                Name = x.Name,
                Age = x.Age
            }).ToList();
            return usuarios;
        }
    }
}
