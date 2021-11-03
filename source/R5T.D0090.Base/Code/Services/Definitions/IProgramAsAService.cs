using System;

using R5T.T0064;


namespace R5T.D0090
{
    /// <summary>
    /// Empty marker interface to communicate that a type is a program-as-a-service.
    /// </summary>
    [ServiceDefinitionMarker]
    public interface IProgramAsAService : IServiceDefinition
    {
    }
}
