using KeyWorkerService.Domain.Abstractions.Default;
using KeyWorkerService.Domain.Models.Default;
using KeyWorkerService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace KeyWorkerService.Infrastructure.Repositories.Default
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
