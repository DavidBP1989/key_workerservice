namespace KeyWorkerService.Domain.Abstractions
{
    public interface IEntryPointService
    {
        /// <summary>
        /// Carga catalogo unico en QlikSense
        /// </summary>
        /// <param name="delay"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task LoadCUtoQS(int delay, CancellationToken cancellationToken);
        Task AnotherTask();
    }
}
