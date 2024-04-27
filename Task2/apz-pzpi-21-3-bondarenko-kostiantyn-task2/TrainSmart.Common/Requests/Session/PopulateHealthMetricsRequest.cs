using TrainSmart.Domain.Enums;

namespace TrainSmart.Common.Requests.Session;

public class PopulateHealthMetricsRequest
{
    public Guid TeamAthleteId { get; set; }
    public Dictionary<HealthMetricType, double> Metrics { get; set; }
}