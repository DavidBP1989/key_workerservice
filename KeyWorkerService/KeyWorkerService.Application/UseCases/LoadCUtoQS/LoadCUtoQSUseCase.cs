using KeyWorkerService.Domain.Abstractions;

namespace KeyWorkerService.Application.UseCases.LoadCUtoQS
{
    public class LoadCUtoQSUseCase : ILoadCUtoQS
    {
        private readonly IServiceLocator _service;
        public LoadCUtoQSUseCase(IServiceLocator service)
        {
            _service = service;
        }

        public async Task DoWork()
        {
            var repositoryDefault = _service.Get<Domain.Abstractions.Default.IRequestUsuarioRepository>();
            var repositoryTblSEXTE = _service.Get<Domain.Abstractions.TblSEXTE.IRequestUsuarioRepository>();

            await repositoryTblSEXTE.Delete();
            var rows = await repositoryDefault.GetAll();
            if (rows.Any())
            {
                var rowsTblSEXTE = rows.Select(x => new Domain.Models.TblSEXTE.UsuarioRequest
                {
                    Name = x.Name,
                    LastName = "",
                    Age = x.Age
                });
                await repositoryTblSEXTE.Insert(rowsTblSEXTE);
            }
        }
    }
}
