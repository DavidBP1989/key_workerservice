namespace KeyWorkerService.Application.UseCases.LoadCUtoQS
{
    public interface ILoadCUtoQS
    {
        /// <summary>
        /// Migrar informaicon de catalogo unico a QlikSense
        /// </summary>
        /// <returns></returns>
        Task DoWork();
    }
}
