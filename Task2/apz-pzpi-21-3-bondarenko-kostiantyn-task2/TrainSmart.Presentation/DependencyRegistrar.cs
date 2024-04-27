using TrainSmart.Application.MappingProfiles;

namespace TrainSmart.Presentation;

public static class DependencyRegistrar
{
    public static void ConfigurePresentationLayerDependencies(
        this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(TeamMappingProfile).Assembly);
    }
}