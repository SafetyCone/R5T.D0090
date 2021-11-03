using System;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using R5T.T0064;


namespace R5T.D0090
{
    // Hosted service program implemented using background service for simplicity and ease of use provided by the background service base class.
    [ServiceImplementationMarker]
    public abstract class ProgramAsAServiceBase : BackgroundService, IProgramAsAService, IServiceImplementation
    {
        private IHostApplicationLifetime HostApplicationLifetime { get; }
        protected IServiceProvider ServiceProvider { get; }


        public ProgramAsAServiceBase(
            IServiceProvider serviceProvider)
        {
            this.ServiceProvider = serviceProvider;

            this.HostApplicationLifetime = this.ServiceProvider.GetRequiredService<IHostApplicationLifetime>();
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return this.ServiceMainWrapper(stoppingToken);
        }

        private async Task ServiceMainWrapper(CancellationToken stoppingToken)
        {
            try
            {
                await this.ServiceMain(stoppingToken);
            }
            // Should do some exception logging or otherwise report the error, maybe a custom exception type that we can stop on?
            finally
            {
                // Stop the application when it is done.
                this.HostApplicationLifetime.StopApplication();
            }
        }

        // Named "ServiceMain" to avoid collision with .NET required Program.Main() entry point.
        protected abstract Task ServiceMain(CancellationToken stoppingToken);
    }
}
