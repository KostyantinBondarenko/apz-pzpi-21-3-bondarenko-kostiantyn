using MediatR;
using TrainSmart.Domain.Enums;

namespace TrainSmart.Application.Session.Commands.PopulateHealthMetrics;

public record PopulateHealthMetricsCommand(
    Guid SessionId,
    Guid TeamAthleteId,
    Dictionary<HealthMetricType, double> Metrics): IRequest<Unit>;