using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.T0072;

using R5T.D0090;


namespace System
{
    public static class IHasConfigureServicesExtensions
    {
        public static TServicesBuilder UseProgramAsAService<TProgramAsAService, TServicesBuilder>(this TServicesBuilder servicesBuilder)
            where TServicesBuilder : IHasConfigureServices<TServicesBuilder>
            where TProgramAsAService : ProgramAsAServiceBase
        {
            servicesBuilder.ConfigureServices(services =>
            {
                services.AddHostedService<TProgramAsAService>();
            });

            return servicesBuilder;
        }
    }
}
