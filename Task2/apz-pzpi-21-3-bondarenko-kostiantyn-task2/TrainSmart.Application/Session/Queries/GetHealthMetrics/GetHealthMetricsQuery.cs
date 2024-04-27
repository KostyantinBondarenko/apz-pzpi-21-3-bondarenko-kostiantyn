using MediatR;
using TrainSmart.Common.DTOs.HealthMetric;
using TrainSmart.Domain.Enums;

namespace TrainSmart.Application.Session.Queries.GetHealthMetrics;

public record GetHealthMetricsQuery(
    Guid SessionId,
    Guid? TeamAthleteId = default,
    HealthMetricType? MetricType = default,
    DateTime? DateFrom = default,
    DateTime? DateTo = default): IRequest<List<HealthMetricDto>>;